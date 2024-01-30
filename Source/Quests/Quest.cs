using Godot;
using System;

public partial class Quest : Node
{
    private bool _active;
    private string _name;
    private string description;

    // Item _reward;

    // A previous quest that may need to have been completed to start the current one.
    Quest _requiredToActivate;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public bool Activate()
    {
        if (!_active)
        {
            // Check conditions, set active to true if met and slot it into the active quest

            _active = true;
        }

        return _active;
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
