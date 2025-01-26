#if TOOLS
using Godot;
using System;
using System.Text.Json;

[Tool]
public partial class StatsEditor : EditorPlugin
{
	private Dictionary<string, Stat> _stats;
	private Stat _newStat;
	private LineEdit _statName;

	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.

		_stats = new Dictionary<string, Stat>();
		PackedScene StatsScene = ResourceLoader.Load<PackedScene>("res://addons/statseditor/Stats Editor.tscn");
	}

	public void Save()
	{

	}

	public void Load()
	{

	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		_stats = null;
	}
}
#endif
