using Godot;
using System;

// There can be more in here, these are just examples
public enum BuffType { TIMED, PERMA };

public partial class Buff : Node
{
    float _buff;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Need to add logic per buff type, could be it only applies for x time or has a certian equation
    public float ApplyBuff()
    {
        return _buff;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
