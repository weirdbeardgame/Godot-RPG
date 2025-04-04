using Godot;
using System;

[GlobalClass]
public partial class ItemCheck : Condition
{
    private enum CheckType{Exists, NotExists}
    [Export] CheckType Type = CheckType.Exists;

    // Placeholder below, later should use resource exports instead
    [Export] public string CharacterInventory; 
    [Export] public string Item;


    public override bool CheckCondition()
    {
        // if no Character or Item or no TargetItem: return false and warn but don't crash the game

        switch (Type)
        {
            case CheckType.Exists:
                // if CharacterInventory.has_item(TargetItem) return true, else return false
                return false;


            case CheckType.NotExists:
                // if CharacterInventory.has_item(TargetItem) return true, else return false
                return false;


            default:
                return false;
        }
    }

}
