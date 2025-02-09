#if TOOLS
using Godot;
using Levels;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.IO;

[Tool]
public partial class LevelDockScript : Control
{
    private Button _save;
    private Button _refresh;
    private Button _newLevelButton;
    private int _currentIndex;
    private Vector2 _currentPosition;

    private FileDialog _dialog;
    private FileSelector _playerRef;
    private ItemList _levelSelector;
    private PackedScene _sceneButton;
    private FileSelector _newGameScene;
    private SceneManagerPlugin _sceneManagerPlugin;
    private SceneManager _sceneManager;

    // Called when the node enters the scene tree for the first time.
    public void Init()
    {
        _dialog = GetNode<FileDialog>("FileDialog");
        _sceneManager = SceneManager.Manager;
        _sceneManagerPlugin = new SceneManagerPlugin();
        _save = GetNode<Button>("HBoxContainer/Save");
        _refresh = GetNode<Button>("HBoxContainer/Refresh");
        _newLevelButton = GetNode<Button>("HBoxContainer/NewLevel");

        _save.Pressed += Save_Button;
        _refresh.Pressed += Refresh_Button;
        _newLevelButton.Pressed += NewLevel_Button;

        _playerRef = GetNode<FileSelector>("FilePickerContainer/PlayerRef");
        _playerRef.BrowseButton.Pressed += SelectPlayerRefrence_Button;
        _playerRef.FileSelected += SetPlayerRefrence;
        if (_sceneManager.PackedPlayer != null)
        {
            _playerRef.SetPathField(_sceneManager.PackedPlayer.ResourcePath);
        }

        _sceneButton = ResourceLoader.Load<PackedScene>("addons/SceneManager/LevelSelectorButton.tscn");

        _newGameScene = GetNode<FileSelector>("FilePickerContainer/NewGameScene");
        _newGameScene.BrowseButton.Pressed += SetNewGameScene_Button;
        _newGameScene.FileSelected += SetNewGameScene;
        if (_sceneManager.NewGameScene != null)
        {
            _newGameScene.SetPathField(_sceneManager.NewGameScene.ResourcePath);
        }

        _levelSelector = GetNode<ItemList>("VBoxContainer/ItemList");
        //_levelSelector.Add.Pressed += AddScene_Button;
        //_levelSelector.Remove.Pressed += RemoveScene_Button;

        _dialog.FileSelected += AddScene;
        //ItemList.s_IndexUpdate += UpdateIndex;
        _sceneManagerPlugin.ManagerRefresh += UpdateList;

        UpdateList();
    }

    void AddScene_Button()
    {
        _dialog.Popup();
    }

    void RemoveScene_Button()
    {
        DirAccess.RemoveAbsolute($"res://Assets/resources/Levels/Scenes/{_levelSelector.GetItemText(_currentIndex)}.tscn");
        DirAccess.RemoveAbsolute($"res://Assets/resources/Levels/LevelData/{_levelSelector.GetItemText(_currentIndex)}.json");
        _sceneManagerPlugin.Remove(_levelSelector.GetItemText(_currentIndex));
        _levelSelector.RemoveItem(_currentIndex);
    }

    void AddScene(string path)
    {
        var scene = (PackedScene)ResourceLoader.Load(path);
        var level = scene.Instantiate<LevelCommon>();
        if (_sceneManagerPlugin.Add(level.LevelName, scene))
        {
            GD.Print($"Scene Added {level.LevelName}");
            UpdateList();
        }
    }

    void Save_Button() => _sceneManager.Save();
    void Refresh_Button() => _sceneManagerPlugin.Refresh();
    void SelectPlayerRefrence_Button() => _playerRef.Open();
    void SetPlayerRefrence() => _sceneManagerPlugin.SetPlayerRef(_playerRef.Path);
    void SetNewGameScene() => _sceneManagerPlugin.SetNewGameScene(_newGameScene.Path);
    void SetNewGameScene_Button() => _newGameScene.Open("Assets/resources/Levels/Scenes", new string[] { "*.tscn" });

    void UpdateIndex(int i)
    {
        _currentIndex = i;
        _sceneManagerPlugin.ChangeSceneInEditor(_sceneManagerPlugin.SceneNames[_currentIndex]);
    }

    void UpdateList()
    {
        if (_sceneManagerPlugin.SceneNames != null)
        {
            if (_sceneManagerPlugin.SceneNames.Count() > 0)
            {
                foreach (var scene in _sceneManagerPlugin.SceneNames)
                {
                    _levelSelector.AddItem(scene);
                }
            }

            if (_levelSelector.ItemCount > _sceneManagerPlugin.SceneNames.Count())
            {
                CallDeferred(nameof(RemoveDeferred));
            }
        }
    }

    public PackedScene CreateLevel()
    {
        var scene = new Level();
        scene.LevelName = $"Level {_sceneManager.LevelCount + 1}";
        scene.Name = scene.LevelName;
        var TileMap = new TileMapLayer();
        TileMap.Name = "Layer";
        scene.AddChild(TileMap);
        TileMap.Owner = scene;
        var packedLevel = new PackedScene();
        packedLevel.Pack(scene);
        packedLevel.ResourceName = scene.LevelName;
        packedLevel.ResourcePath = $"res://Assets/resources/Levels/Scenes/{scene.LevelName}.tscn";
        ResourceSaver.Save(packedLevel, $"res://Assets/resources/Levels/Scenes/{scene.LevelName}.tscn");
        return packedLevel;
    }

    public void NewLevel_Button()
    {
        var scene = CreateLevel();
        _sceneManagerPlugin.Add(scene.ResourceName, scene);
        _sceneManager.Save();
        UpdateList();
        _sceneManagerPlugin.ChangeSceneInEditor(scene.ResourceName);
    }

    void RemoveDeferred()
    {
    }
}
#endif
