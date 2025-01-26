using Godot;
using Levels;
using System;
using System.Text.Json.Serialization;

[Tool]
public partial class SceneManagerData
{
    public string CurrentLevel { get; set; }
    [JsonConverter(typeof(PackedSceneJsonConverter))] public PackedScene NewGameScene { get; set; }
    [JsonConverter(typeof(DictionaryPackedSceneJsonConverter))] public Dictionary<string, PackedScene> Levels { get; set; }

    [JsonConverter(typeof(PackedSceneJsonConverter))] public PackedScene PackedPlayer { get; set; }

    public SceneManagerData() => Levels = new Dictionary<string, PackedScene>();
    public SceneManagerData(Dictionary<string, PackedScene> lev) => Levels = lev;

    // Returns the instantiated packed scene as a Level.
    public LevelCommon Level(string levelName) => Levels[levelName].Instantiate<LevelCommon>();

    // Returns the active Player refrence
    public Player CreatePlayer() => PackedPlayer.Instantiate<Player>();

#if TOOLS
    public void SetPlayerRef(string path) => PackedPlayer = ResourceLoader.Load<PackedScene>(path);

    public bool Add(string LevelName, PackedScene Scene)
    {
        if (string.IsNullOrEmpty(LevelName))
        {
            GD.PrintErr("Level has no name!");
        }

        if (!Levels.ContainsKey(LevelName))
        {
            Levels.Add(LevelName, Scene);
            return true;
        }
        else
        {
            GD.PrintErr("Scene already exists");
        }
        return false;
    }

    public bool Remove(string SceneName)
    {
        if (Levels.ContainsKey(SceneName))
        {
            Levels.Remove(SceneName);
            return true;
        }
        GD.PrintErr("Scene does not exist in manager");
        return false;
    }

    public void Refresh()
    {
        foreach (var scene in Levels)
        {
            if (!ResourceLoader.Exists(scene.Value.ResourcePath))
            {
                Remove(scene.Key);
            }
        }
    }

    public void SetNewGameScene(string path)
    {
        LevelCommon l = ResourceLoader.Load<PackedScene>(path).Instantiate<LevelCommon>();
        if (Levels.ContainsKey(l.LevelName))
        {
            NewGameScene = Levels[l.LevelName];
        }
        else
        {
            Levels.Add(l.LevelName, ResourceLoader.Load<PackedScene>(path));
            NewGameScene = Levels[l.LevelName];
        }
    }
#endif

};