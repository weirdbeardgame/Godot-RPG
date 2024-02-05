using Godot;
using System;

public partial class Quest : Resource
{
    [Export]
    private bool _Active;

    [Export]
    private string _Name;

    [Export]
    private string _Description;

    [Export]
    int _Amt;

    [Export]
    Variant _RequiredToStart;

    [Export]
    Godot.Collections.Dictionary<string, Goal> _QuestGoals;
    [Export]
    Godot.Collections.Array<QuestRequirement> _Requirements;

    public bool IsActive => _Active;

    public bool Start()
    {
        if (!_Active)
        {
            foreach (var Required in _Requirements)
            {
                if (!Required.Check(_Amt, _RequiredToStart))
                {
                    return false;
                }
            }
            _Active = true;
        }

        return _Active;
    }


    public void Stop()
    {
        _Active = false;
    }

}
