using Godot;
using System;

[GlobalClass]
public abstract partial class GameOutcome : Resource
{
    public abstract void PerformOutcome();
}
