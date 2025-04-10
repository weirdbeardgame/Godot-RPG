using Godot;
using System;

[GlobalClass]
public abstract partial class GameOutcome : Resource
{
    // Outcome could be calling GiveReward, Player Death, Quest Complete, etc.
    public abstract void PerformOutcome();
}
