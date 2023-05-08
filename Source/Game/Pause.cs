using Godot;
using System;

namespace RPG;

public partial class Pause : State
{
    // Ready happens before start
    public override void _Ready()
    {
        StateName = "Pause";
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.AddState(this, StateName);
    }

    public override void Start()
    {
        GetTree().Paused = true;
    }

    public override void Stop()
    {
        GetTree().Paused = false;
    }
}