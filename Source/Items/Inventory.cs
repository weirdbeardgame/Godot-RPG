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
    // Vector2 _SlotSize;
    // Vector2 _SlotPosition;

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
            _Amount += 1;
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
    // Note, this is to be the total count of Items, not count of slots
    // Though in some Games this could be the same
    [Export]
    int _InvMax;
    [Export]
    int _Amount;

    [Export]
    Godot.Collections.Dictionary<string, ItemSlot> _ItemInv;

    public static Action ItemAddedEvent;
    public static Action UseItemEvent;
    public static Action<Godot.Collections.Array<Item>> AddItemEvent;

    public static int ItemAmtAdded;
    public static Item ItemAdded;

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
        _ItemInv = new Godot.Collections.Dictionary<string, ItemSlot>();
        AddItemEvent += AddItem;
    }

    public void AddItem(Godot.Collections.Array<Item> ToAdd)
    {
        if (_Amount < _InvMax)
        {
            ItemAdded = ToAdd[0];
            ItemAmtAdded = ToAdd.Count;
            foreach (var Item in ToAdd)
            {
                if (_ItemInv.ContainsKey(Item.ItemName))
                {
                    _ItemInv[Item.ItemName].Add(Item);
                    _Amount += 1;
                }
                else
                {
                    _ItemInv.Add(Item.ItemName, new ItemSlot(Item));
                    _Amount += 1;
                    // _CurrentInventoryWeight += _ItemInv[ToAdd].GetWeight;
                    ItemAddedEvent.Invoke();
                }
            }
        }
    }

    public Item UseItem(string ItemName)
    {
        // Amount is subtracted from, to lower the total count of items
        _Amount -= 1;
        return _ItemInv[ItemName].GetItem();
    }
}
