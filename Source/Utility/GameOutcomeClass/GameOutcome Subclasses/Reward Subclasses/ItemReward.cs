using Godot;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Core.Items;

[GlobalClass]
public partial class ItemReward : Reward
{
    // placeholder below, CharacterInventory should be resource
    [Export] public string CharacterInventory;
    [Export] public Godot.Collections.Array<Item> ItemRewards;

    public override void GiveReward()
    {
        // CharacterInventory.add_item(Item)
        // a better approach would be to use a dedicated utility class to handle similar game logic consistently across the project
    }
}
