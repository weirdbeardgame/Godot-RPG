using Godot;
using System;
using System.Collections.Generic;

// A Class to be inherited from. Creatures are units stats.
public partial class Creature : Node
{
    // Stats are objects that can be dynamically constructed and set!
    protected List<Stat> Stats;
    protected string CreatureName;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }
}
