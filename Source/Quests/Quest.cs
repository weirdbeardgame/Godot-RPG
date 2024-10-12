using Godot;
using System;



public partial class Quest : Resource
{
    [Export]
    private bool _active;

    [Export]
    private string _name;

    [Export]
    private string _description;

    StateMachine _stateMachine;

    Dictionary<string, Goal> _questGoals;
    List<QuestRequirement> _requirements;

    public bool IsActive => _active;
    public string QuestName => _name;
    public string QuestDescription => _description;

    public Quest(string name, string desc)
    {
        _name = name;
        _description = desc;
    }


    public bool Start()
    {
        return _active;
    }


    public void Stop()
    {
        _active = false;
    }

}
