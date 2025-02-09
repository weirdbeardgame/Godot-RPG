#if TOOLS
using Godot;
using System;
using System.Text.Json;

[Tool]
public partial class StatsEditor : Control
{
	private Dictionary<string, Stat> _stats;
	private Stat _currentStat;
	private LineEdit _statName;
	private ItemList _statsList;
	private Button _add;
	private Button _remove;
	private JsonWrapper _json = new JsonWrapper();

	public override void _EnterTree()
	{
		_stats = new Dictionary<string, Stat>();
		_statsList = GetNode<ItemList>("StatsList");
		_statName = GetNode<LineEdit>("VBoxContainer/StatName");
		_add = GetNode<Button>("HBoxContainer/AddStat");
		_remove = GetNode<Button>("HBoxContainer/RemoveStat");


		_add.Pressed += New;
		//_remove.Pressed += Remove;

	}

	public void New()
	{
		if (string.IsNullOrEmpty(_statName.Text))
		{
			_statName.Text = $"Stat: {_stats.Count}";
		}

		if (!_stats.ContainsKey(_statName.Text))
		{
			_currentStat = new Stat(_statName.Text, 1000);
			_stats.Add(_currentStat.StatName, _currentStat);
			_statsList.AddItem(_currentStat.StatName);
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
		if (!_json.Write("res://StatsData.json", _stats))
		{
			GD.PrintErr("Save Failed!");
		}
	}

	public void Load()
	{
		// Look Vegeta, more Json stuff.
		if (!_json.Read("res://StatsData.json", ref _stats))
		{
			GD.PrintErr("Failed to parse Stats!");
		}
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		_stats = null;
	}
}
#endif
