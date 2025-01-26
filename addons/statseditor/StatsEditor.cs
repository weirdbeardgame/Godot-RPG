#if TOOLS
using Godot;
using System;
using System.Text.Json;

[Tool]
public partial class StatsEditor : EditorPlugin
{
	private Dictionary<string, Stat> _stats;
	private Stat _currentStat;
	private LineEdit _statName;
	private ItemList _statsList;

	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.

		_stats = new Dictionary<string, Stat>();
		_statsList = GetNode<ItemList>("StatsList");
		PackedScene StatsScene = ResourceLoader.Load<PackedScene>("res://addons/statseditor/Stats Editor.tscn");
		var instance = StatsScene.Instantiate<Control>();
		EditorInterface.Singleton.GetEditorMainScreen().AddChild(instance);
	}

	public void New()
	{
		if (!_stats.ContainsKey(_statName.Text))
		{
			_currentStat = new Stat(_statName.Text, 1000);
			_stats.Add(_currentStat.StatName, _currentStat);
		}
	}

	public void Remove(string name) => _stats.Remove(name);

	public void SetStat(float value)
	{
		if (value >= 0 && value <= _currentStat.MaxStat)
		{
			_currentStat.GetStat = value;
		}
	}

	public void SetMaxStat(float value)
	{
		if (value >= 0)
		{
			_currentStat.MaxStat = value;
		}
	}

	public void Save()
	{
		// Jsssonnnn!!
	}

	public void Load()
	{
		// Look Vegeta, more Json stuff.
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		_stats = null;
	}
}
#endif
