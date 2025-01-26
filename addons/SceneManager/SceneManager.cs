using Godot;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Levels;
using System.Text.Json;

[Tool]
public partial class SceneManager : Node
{
    public static Action ResetLevel;
    public static Action StartNewGame;
    public static Action<string, Player> ChangeScene;
    public static Action<PackedScene, Player, Exit> ChangeSceneWithExit;

    private LevelCommon currentScene;
    private JsonWrapper _json = new JsonWrapper();
    private string _sceneManagerPath = "res://SceneManagerData.json";

    public SceneManagerData ManagerData;
    public int LevelCount => ManagerData.Levels.Count;
    public PackedScene NewGameScene => ManagerData.NewGameScene;
    public PackedScene PackedPlayer => ManagerData.PackedPlayer;

    // Because Plugin exists outside the SceneTree, we create our own _Tree or refrence to one.
    private static SceneTree s_tree;

    private Player playerRef;

    public Player ActivePlayerRef
    {
        get
        {
            if (playerRef == null)
            {
                playerRef = ManagerData.CreatePlayer();
            }
            return playerRef;
        }
        set
        {
            playerRef = value;
        }
    }

    private static SceneManager s_sceneManager;
    public static new SceneTree GetTree() => s_tree;
    public LevelCommon CurrentScene => currentScene;

    public bool Save()
    {
        if (!_json.Write(_sceneManagerPath, ManagerData))
        {
            GD.PrintErr("Failed to save Scene Manager");
            return false;
        }
        return true;
    }

    public bool Load()
    {
        if (!_json.Read(_sceneManagerPath, ref ManagerData))
        {
            GD.PrintErr("Failed to save Scene Manager");
            return false;
        }
        return true;
    }

    public static SceneManager Manager
    {
        get
        {
            if (s_sceneManager == null)
            {
                s_sceneManager = new SceneManager();
            }
            return s_sceneManager;
        }
    }

    // Call this from your TitleScreen or other beginning scripts in game.
    // Because SceneManager exists as a plugin it does not exist in SceneTree
    // As such _Ready will not be called.
    public void Init(SceneTree T)
    {
        s_tree = new SceneTree();
        StartNewGame += NewGame;
        ChangeScene += SwitchLevel;
        ChangeSceneWithExit += LoadSubScene;
        ResetLevel += Reset;
        s_tree = T;

        if (Load())
        {
            playerRef = ManagerData.CreatePlayer();
        }
    }

    void Reset() => currentScene.ResetLevel();
    public void DestroyPlayer(Player p) => p.Dispose();
    public void LoadSubScene(PackedScene subscene, Player p, Exit exit) => CallDeferred(nameof(CallDeferredSub), subscene.Instantiate<LevelCommon>(), p);

    public bool CreateManagerData()
    {
        if (!ResourceLoader.Exists(_sceneManagerPath))
        {
            GD.Print("No SceneManager Data!");
            ManagerData = new SceneManagerData();
        }
        else
        {
            if (!Load())
            {
                throw new Exception("Unable to load SceneManager!");
            }
        }
        return false;
    }

    // Play level changing animation.
    // Load new scene and set it as current
    public void SwitchLevel(string scene, Player player)
    {
        // This is what's passing instance of player across scenes!!!
        ActivePlayerRef = player;
        if (ManagerData.Levels.ContainsKey(scene))
        {
            Switch(ManagerData.Level(scene), ref currentScene);
        }
        else
        {
            GD.PrintErr("INVALID LEVEL SELECTED: " + scene);
        }
    }

    public LevelCommon GetLevel(string LevelName)
    {
        if (ManagerData.Levels.ContainsKey(LevelName))
        {
            return ManagerData.Level(LevelName);
        }
        return null;
    }

    void CallDeferredSub(SubLevel toLoad, Player Player)
    {
        currentScene.ExitLevel();
        currentScene.EnterSubLevel(Player, toLoad);
    }

    void Switch(LevelCommon toLoad, ref LevelCommon current)
    {
        using var title = s_tree.Root.GetNodeOrNull<TitleScreen>("TitleScreen");

        if (current != null)
        {
            s_tree.Root.RemoveChild(current);
            current.QueueFree();
        }
        else if (title != null)
        {
            s_tree.Root.RemoveChild(title);
        }
        current = toLoad;
        s_tree.Root.AddChild(current);
        s_tree.CurrentScene = current;
        current.EnterLevel();
    }

    void NewGame()
    {
        LevelCommon scene = ManagerData.NewGameScene.Instantiate<LevelCommon>();
        SwitchLevel(scene.LevelName, null);
        StartNewGame -= NewGame;
    }
}
