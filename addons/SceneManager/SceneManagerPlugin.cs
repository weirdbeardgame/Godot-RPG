#if TOOLS
using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

[Tool]
public partial class SceneManagerPlugin : EditorPlugin
{
	public Action ManagerRefresh;
	private SceneManager _sceneManager = SceneManager.Manager;
	private Control _editorDock;

	// Initialization of the plugin goes here.
	public override void _EnterTree()
	{
		base._EnterTree();
		GD.Print("EnterTree");

		_sceneManager.CreateManagerData();

		EditorInterface.Singleton.GetResourceFilesystem().FilesystemChanged += _sceneManager.ManagerData.Refresh;

		ManagerRefresh += _sceneManager.ManagerData.Refresh;

		_editorDock = GD.Load<PackedScene>("res://addons/SceneManager/LevelDock.tscn").Instantiate<Control>();

		var levelDock = (LevelDockScript)_editorDock;
		AddControlToDock(DockSlot.LeftUl, levelDock);
		levelDock.Init();
		ManagerRefresh?.Invoke();
	}

	public void Refresh() => ManagerRefresh?.Invoke();
	public void Remove(string SceneName) => _sceneManager.ManagerData.Remove(SceneName);
	public void SetPlayerRef(string path) => _sceneManager.ManagerData.SetPlayerRef(path);
	public bool Add(string name, PackedScene scene) => _sceneManager.ManagerData.Add(name, scene);
	public void SetNewGameScene(string sceneName) => _sceneManager.ManagerData.SetNewGameScene(sceneName);


	public List<string> SceneNames
	{
		get
		{
			if (_sceneManager.ManagerData != null && _sceneManager.ManagerData.Levels != null)
			{
				return _sceneManager.ManagerData.Levels.Keys.ToList<string>();
			}
			return null;
		}
	}

	public void ChangeSceneInEditor(string SceneName)
	{
		if (_sceneManager.ManagerData.Levels != null)
		{
			EditorInterface.Singleton.OpenSceneFromPath(_sceneManager.ManagerData.Levels[SceneName].ResourcePath);
		}
	}

	public override void _ExitTree()
	{
		if (_editorDock != null)
		{
			RemoveControlFromDocks(_editorDock);
			_editorDock.Free();
		}
	}
}


#endif
