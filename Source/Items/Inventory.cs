using Godot;
using System;
using System.Linq;

public partial class ItemSlot : Resource
{

    [Export]
    int _MaxAllowed;

    [Export]
    int _Amount;

    // Could be for a Weight based Inventory
    /*[Export]
    int _SlotWeight;
    int GetWeight => _SlotWeight;
    */

    // For Slot organizer types
    // Vector2 SlotSize;
    // Vector2 SlotPosition;

    [Export]
    Godot.Collections.Array<Item> _Item;

    public ItemSlot(Item I)
    {
        if (_Item == null)
        {
            _Item = new Godot.Collections.Array<Item>();
        }
        _Item.Add(I);
        _Amount += 1;
    }

    public bool Add(Item I)
    {
        if (_Amount < _MaxAllowed)
        {
            _Item.Add(I);
            return true;
        }
        return false;
    }

    public Item GetItem()
    {
        if (_Amount > 0)
        {
            _Amount -= 1;
            Item I = _Item[0];
            _Item.RemoveAt(0);
            return I;
        }

        return null;
    }
}

public partial class Inventory : Node
{
    // To Check if Inv is full period
    [Export]
    int _InvMax;
    [Export]
    int _Amount;
    [Export]
    Godot.Collections.Dictionary<string, ItemSlot> ItemInv;

    /*
    // Could do some maffs with player strength if so desired.
    int _MaxWeightCanCarry;
    // Add all slots and the amount of items in them together!
    int _CurrentInventoryWeight;
    public bool TooHeavy => _CurrentInventoryWeight >= _MaxWeightCanCarry;
    */

    public override void _Ready()
    {
        base._Ready();
        ItemInv = new Godot.Collections.Dictionary<string, ItemSlot>();
    }

    public bool AddItem(Item ToAdd)
    {
        if (_Amount < _InvMax)
        {
            if (ItemInv.ContainsKey(ToAdd.ItemName))
            {
                ItemInv[ToAdd.ItemName].Add(ToAdd);
                return true;
            }
            else
            {
                ItemInv.Add(ToAdd.ItemName, new ItemSlot(ToAdd));
                // _CurrentInventoryWeight += ItemInv[ToAdd].GetWeight;
            }
        }
        return false;
    }

    public Item UseItem(string ItemName) => ItemInv[ItemName].GetItem();

}
