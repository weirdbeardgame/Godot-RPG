using Godot;
using System;

[GlobalClass]
public partial class MoneyReward : Reward
{
    // placeholder below, I don't know where money will be stored for characters but its not going to be a string that's for sure
    [Export] public string Character = "Player";
    [Export] public float Money;

    public override void GiveReward()
    {
        // Character.add_money(Money)
        // a better approach would be to use a dedicated utility class to handle similar game logic consistently across the project
    }
}
