using Godot;
using System;

[GlobalClass]
public partial class ExperienceReward : Reward
{
    // placeholder below, CharacterStat needs to be a resource
    [Export] public string CharacterStat = "PlayerStat";
    [Export] public float Experience;

    public override void PerformOutcome()
    {
        // CharacterStat.exp += Experience
        // a better approach would be to use a dedicated utility class to handle similar game logic consistently across the project
    }
}
