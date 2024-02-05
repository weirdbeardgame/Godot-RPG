using Godot;
using System;

public partial class Quest : Resource
{
    private bool _Active;
    private string _Name;
    private string _Description;

    Dictionary<string, Goal> _QuestGoals;

    Item _reward;

    // A previous quest that may need to have been completed to start the current one.
    Quest _requiredToActivate;

    public bool IsActive => _Active;

    public bool Start()
    {
        if (!_Active)
        {
            // Check conditions, set active to true if met and slot it into the active quest

            _Active = true;
        }

        return _Active;
    }


    public void Stop()
    {
        _Active = false;
    }

}
