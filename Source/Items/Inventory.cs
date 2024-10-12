using Godot;
using System;
using System.Linq;

public partial class ItemSlot : Resource
{
    [Export]
    int _maxAllowed;

    [Export]
    int _amount;

    // Could be for a Weight based Inventory
    /*[Export]
    private int _slotWeight;
    private int GetWeight => _slotWeight;
    */

    // For Slot organizer types
    // private Vector2 _slotSize;
    // private Vector2 _slotPosition;


    private List<Item> _items;

    public ItemSlot(Item I)
    {
        if (_items == null)
        {
            _items = new List<Item>();
        }
        _items.Add(I);
        _amount += 1;
    }

    public bool Add(Item I)
    {
        if (_amount < _maxAllowed)
        {
            _items.Add(I);
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
            Item I = _items[0];
            _items.RemoveAt(0);
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
    int _invMax;
    [Export]
    int _amount;

    [Export]
    Dictionary<string, ItemSlot> _itemInv;

    public static Action ItemAddedEvent;
    public static Action UseItemEvent;
    public static Action<List<Item>> AddItemEvent;

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
        AddItemEvent += AddItem;
    }

    public void AddItem(List<Item> toAdd)
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
                    // _CurrentInventoryWeight += _ItemInv[ToAdd].GetWeight;
                    ItemAddedEvent.Invoke();
                }
            }
        }
    }

    public Item UseItem(string ItemName)
    {
        // Amount is subtracted from, to lower the total count of items
        _amount -= 1;
        return _itemInv[ItemName].GetItem();
    }
}
