using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[Tool]
public partial class ItemList : Control
{
    private int _itemCount;
    private int _currentIndex;
    private List<Button> _items;
    private VBoxContainer _itemContainer;

    // Control Buttons
    public Button Add;
    public Button Remove;
    public int ItemCount => _itemCount;
    public List<Button> Items => _items;
    public int CurrentIndex => _currentIndex;
    public Button GetItem(int index) => _items[index];

    public static Action<int> s_IndexUpdate;


    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {
        _itemCount = 0;
        _items = new List<Button>();
        Add = GetNode<Button>("HBoxContainer/Add");
        Remove = GetNode<Button>("HBoxContainer/Remove");
        _itemContainer = GetNode<VBoxContainer>("ItemBox/ScrollContainer/ItemContainer");
    }

    public void AddItem(Button item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
            GD.Print(_items);
            _itemContainer.AddChild(_items.Last());
            _itemCount = _items.Count;
            item.Pressed += () => ItemSelected(item.Text);
        }
    }

    void ItemSelected(string name)
    {
        GD.Print(name);
        Button b = Contains(name);
        _currentIndex = _items.FindIndex(b => b.Text == name);
        s_IndexUpdate(_currentIndex);
    }


    public Button Contains(string name)
    {
        foreach (var btn in _items)
        {
            if (btn.Text.Contains(name))
            {
                return btn;
            }
        }
        return null;
    }

    public void RemoveItem(Button btn)
    {
        if (btn != null)
        {
            _itemContainer.RemoveChild(btn);
            _items.Remove(btn);
            _itemCount = _items.Count;
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        if (_items != null)
        {
            _items.Clear();
        }
        _itemCount = 0;
    }

}
