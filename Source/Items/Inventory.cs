using Godot;
using System;
using System.Linq;

namespace Core.Items;

public partial class Inventory : Node
{
    // To Check if Inv is full period
    // Note, this is to be the total count of Items, not count of slots
    // Though in some Games this could be the same
    [Export]
    int _invMax;
    [Export]
    int _amount;

    Dictionary<string, ItemSlot> _itemInv;

    public static Action<string> UseItem;
    public static Action<List<Item>> AddItem;

    public static int ItemAmtAdded;
    public static Item ItemAdded;

    /*
    // Could do some maffs with player strength if so desired.
    private int _maxWeightCanCarry;
    // Add all slots and the amount of items in them together!
    private int _currentInventoryWeight;
    public bool TooHeavy => _currentInventoryWeight >= _maxWeightCanCarry;
    */

    public int InvMax => _invMax;
    public int Amount => _amount;

    public override void _Ready()
    {
        base._Ready();
        _itemInv = new Dictionary<string, ItemSlot>();
        AddItem += Add;
        UseItem += Use;
    }

    public void Add(List<Item> toAdd)
    {
        if (_amount < _invMax)
        {
            ItemAdded = toAdd[0];
            ItemAmtAdded = toAdd.Count;
            foreach (var item in toAdd)
            {
                if (_itemInv.ContainsKey(item.ItemName))
                {
                    _itemInv[item.ItemName].Add(item);
                    _amount += 1;
                }
                else
                {
                    _itemInv.Add(item.ItemName, new ItemSlot(item));
                    _amount += 1;
                }
            }
        }
    }

    public void Use(string itemUid)
    {
        // Amount is subtracted from, to lower the total count of items
        _amount -= 1;
        _itemInv[itemUid].GetItem().Use();
    }
}
