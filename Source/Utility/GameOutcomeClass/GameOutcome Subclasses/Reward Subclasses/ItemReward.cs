using Godot;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

[GlobalClass]
public partial class ItemReward : Reward
{
    // placeholder below, CharacterInventory and Item should be resource
    [Export] public string CharacterInventory;
    [Export] public string Item;

    public override void PerformOutcome()
    {
        // CharacterInventory.add_item(Item)
        // a better approach would be to use a dedicated utility class to handle similar game logic consistently across the project
    }
}
