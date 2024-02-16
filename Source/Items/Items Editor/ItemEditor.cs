using Godot;
using System;

[Tool]
public partial class ItemEditor : Control
{
    Inventory Inv;
    Button Save;
    Button NewItem;

    [Export]
    Godot.Collections.Dictionary<string, Item> _Items;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Save = GetNode<Button>("Save");
        NewItem = GetNode<Button>("NewItem");

        Save.Pressed += Save_Button;
        NewItem.Pressed += NewItem_Button;

        _Items = new Godot.Collections.Dictionary<string, Item>();
    }

    public void NewItem_Button()
    {
        Item ToAdd = new Item(Inv.Amount, Operator.ADD, "Item: " + Inv.Amount, "Default");
        _Items.Add(ToAdd.ItemName, ToAdd);
    }

    public void Save_Button()
    {
    }
}
