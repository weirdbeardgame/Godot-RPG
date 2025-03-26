#if TOOLS
using Godot;
using System;
using System.Linq;
using System.Text.Json.Serialization;


[Tool]
public partial class StatsEditor : Control
{
    // Properties for Item List
    private int _currentIndex;
    private Vector2 _currentPosition;
    private ItemList _statsList;

    // Properties for _stats
    private StatData _currentStat;
    private Dictionary<string, StatData> _stats = new();

    private LineEdit _statName;
    private SpinBox _stat;
    private SpinBox _maxStat;

    private Button _createNewStat;
    private Button _remove;
    private Button _save;

    // PopUp Panel:
    private PopupPanel _statNamePanel;
    private LineEdit _newStatNameEdit;
    private Button _okButton;
    private Button _cancelButton;

    JsonWrapper json = new JsonWrapper();

    const string _filePath = "res://Assets/Data/Stats.json";

    public override void _EnterTree()
    {
        _currentStat = new StatData();
        _statsList = GetNode<ItemList>("StatsList");
        _statName = GetNode<LineEdit>("VBoxContainer/StatName");
        _createNewStat = GetNode<Button>("HBoxContainer/NewStat");
        _save = GetNode<Button>("HBoxContainer/Save");
        _remove = GetNode<Button>("HBoxContainer/RemoveStat");
        _stat = GetNode<SpinBox>("VBoxContainer/Stat");
        _maxStat = GetNode<SpinBox>("VBoxContainer/MaxStat");

        // PopUp Panel
        _statNamePanel = GetNode<PopupPanel>("StatNamePanel");
        _newStatNameEdit = _statNamePanel.GetNode<LineEdit>("VBoxContainer/StatName");
        _okButton = _statNamePanel.GetNode<Button>("VBoxContainer/HBoxContainer/Ok");
        _cancelButton = _statNamePanel.GetNode<Button>("VBoxContainer/HBoxContainer/Cancel");

        _statName.TextChanged += OnStatNameUpdate;
        _statsList.ItemClicked += ItemSelected;
        _stat.ValueChanged += OnStatUpdate;
        _maxStat.ValueChanged += OnMaxStatUpdate;

        _createNewStat.Pressed += New;
        _remove.Pressed += RemoveButton;
        _save.Pressed += Save;

        // PopUp Panel Events
        _okButton.Pressed += OkButtonPressed;
        _cancelButton.Pressed += CancelButtonPressed;


        if (Load())
        {
            Refresh();
            _statsList.Select(0);
            _currentIndex = 0;

            if (_currentStat != _stats[_statsList.GetItemText(_currentIndex)])
            {
                _currentStat = _stats[_statsList.GetItemText(_currentIndex)];
                _statName.Text = _currentStat.StatName;
                _stat.Value = _currentStat.Stat;
                _maxStat.Value = _currentStat.MaxStat;
            }
        }
    }

    public void New()
    {
        _newStatNameEdit.Text = string.Empty;
        _statNamePanel.Popup();
    }

    public void ItemSelected(long idx, Vector2 pos, long mouse_btn)
    {
        _currentIndex = (int)idx;
        _currentPosition = pos;

        // Update UI here

        if (_currentStat != _stats[_statsList.GetItemText(_currentIndex)])
        {
            _currentStat = _stats[_statsList.GetItemText(_currentIndex)];
            _statName.Text = _currentStat.StatName;
            _stat.Value = _currentStat.Stat;
            _maxStat.Value = _currentStat.MaxStat;
        }
    }

    public void CreateNewStat()
    {
        if (string.IsNullOrEmpty(_newStatNameEdit.Text))
        {
            _newStatNameEdit.Text = $"StatData: {_stats.Count}";
        }
        if (!_stats.ContainsKey(_newStatNameEdit.Text))
        {
            var newStat = new StatData(_newStatNameEdit.Text, 0);
            _stats.Add(newStat.StatName, newStat);
            _statsList.AddItem(newStat.StatName);
        }

        _statNamePanel.Hide();
    }

    void OkButtonPressed() => CreateNewStat();
    void CancelButtonPressed() => _statNamePanel.Hide();
    void OnStatNameUpdate(string val)
    {
        var old = _currentStat.StatName;
        _currentStat.StatName = val;

        _stats.Remove(old);
        _stats.Add(_currentStat.StatName, _currentStat);
        Refresh();
    }

    void OnStatUpdate(double val) => _currentStat.Stat = (float)val;
    void OnMaxStatUpdate(double val) => _currentStat.MaxStat = (float)val;
    public void RemoveButton() => Remove(_statName.Text);
    public void Remove(string name)
    {
        _statsList.RemoveItem(_currentIndex);
        _stats.Remove(name);
    }
    public void SetStat(float value)
    {
        if (value >= 0 && value <= _currentStat.MaxStat)
        {
            _currentStat.Stat = value;
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
        if (!json.Write(_filePath, _stats))
        {
            GD.PrintErr("JSON Failed to write");
        }
    }

    public bool Load()
    {
        // Look Vegeta, more Json stuff.
        return json.Read(_filePath, ref _stats);
    }

    public void Refresh()
    {
        _statsList.Clear();
        foreach (var stat in _stats)
        {
            _statsList.AddItem(stat.Key);
        }
    }

    public override void _ExitTree()
    {
        // Clean-up of the plugin goes here.
        _stats = null;

        _statName.TextChanged -= OnStatNameUpdate;
        _statsList.ItemClicked -= ItemSelected;
        _stat.ValueChanged -= OnStatUpdate;
        _maxStat.ValueChanged -= OnMaxStatUpdate;

        _createNewStat.Pressed -= New;
        _remove.Pressed -= RemoveButton;
    }
}
#endif
