using System;
using System.Collections;
using Godot;

namespace Core.Items;

public partial class ItemSlot : Resource
{
    [Export]
    private int _maxAllowed;

    [Export]
    private int _amount;

    // Could be for a Weight based Inventory
    /*[Export]
    private int _slotWeight;
    private int GetWeight => _slotWeight;
    */

    // For Slot organizer types, Resident Evil style
    // private Vector2 _slotSize;
    // private Vector2 _slotPosition;

    private Item _item;

    public ItemSlot(Item i)
    {
        _item = i;
        _amount += 1;
    }

    public bool Add(Item I)
    {
        if (_amount < _maxAllowed)
        {
            _amount += 1;
            return true;
        }
        return false;
    }

    public Item GetItem()
    {
        if (_amount > 0)
        {
            _amount -= 1;
            return _item;
        }

        return null;
    }
}
