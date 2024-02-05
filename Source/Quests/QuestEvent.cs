using Godot;
using System;

public enum EventTypes { CUTSCENE, GIVE, TAKE, DIALOG }

public partial class QuestEvent : Node
{
    protected EventTypes EventType;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
