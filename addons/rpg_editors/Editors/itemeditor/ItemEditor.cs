#if TOOLS
using Godot;
using System;
using System.Text.Json;
using Core.Items;

[Tool]
public partial class ItemEditor : Panel
{
    Button _save;
    Button _newItem;

    // Popup Panel:
    PopupPanel _itemNamePanel;
    LineEdit _panelItemName;
    Button _okButton;
    Button _cancelButton;

    // Item List Properties:
    ItemList _itemList;
    int _currentIndex;
    Vector2 _currentPosition;

    LineEdit _itemName;
    LineEdit _itemDesc;

    private Dictionary<string, Item> _items;
    Item _currentItem;

    JsonWrapper json;
    DirAccess dirAccess;

    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {
        json = new JsonWrapper();
        _save = GetNode<Button>("VSplitContainer/ItemListButtons/Save");
        _newItem = GetNode<Button>("VSplitContainer/ItemListButtons/NewItem");
        _itemName = GetNode<LineEdit>("Control/VBoxContainer/ItemNameField");
        _itemDesc = GetNode<LineEdit>("Control/VBoxContainer/Description");
        _itemList = GetNode<ItemList>("VSplitContainer/Items");

        // Popup Panel:
        _itemNamePanel = GetNode<PopupPanel>("ItemNamePanel");
        _panelItemName = _itemNamePanel.GetNode<LineEdit>("VBoxContainer/ItemName");
        _okButton = _itemNamePanel.GetNode<Button>("VBoxContainer/HBoxContainer/Ok");
        _cancelButton = _itemNamePanel.GetNode<Button>("VBoxContainer/HBoxContainer/Cancel");

        _save.Pressed += Save_Button;
        _newItem.Pressed += NewItem_Button;

        _itemName.TextChanged += NameEdit;
        _itemDesc.TextChanged += DescEdit;
        _itemList.ItemClicked += ItemSelected;

        _okButton.Pressed += OkButtonPressed;
        _cancelButton.Pressed += CancelButtonPressed;

        _items = new Dictionary<string, Item>();

        if (Load())
        {
            Refresh();
            _currentIndex = 0;

            if (_currentItem == null)
            {
                _currentItem = new Item();
            }
            if (_currentItem != _items[_itemList.GetItemText(_currentIndex)])
            {
                _currentItem = _items[_itemList.GetItemText(_currentIndex)];
                _itemName.Text = _currentItem.ItemName;
                _itemDesc.Text = _currentItem.ItemDescription;
            }
        }
    }

    public void ItemSelected(long idx, Vector2 pos, long mouse_btn)
    {
        _currentIndex = (int)idx;
        _currentPosition = pos;

        if (_currentItem == null)
        {
            _currentItem = new Item();
        }
        if (_currentItem != _items[_itemList.GetItemText(_currentIndex)])
        {
            _currentItem = _items[_itemList.GetItemText(_currentIndex)];
            _itemName.Text = _currentItem.ItemName;
            _itemDesc.Text = _currentItem.ItemDescription;
        }
    }


    public void NewItem_Button()
    {
        _panelItemName.Text = string.Empty;
        _itemNamePanel.Popup();
    }

    void CreateNewItem()
    {
        Item toAdd = new Item(Operator.ADD, "Default", "Default");
        if (string.IsNullOrEmpty(_panelItemName.Text))
        {
            _panelItemName.Text = "Item: " + _items.Count;
        }

        toAdd.ItemName = _panelItemName.Text;
        _items.Add(toAdd.ItemName, toAdd);
        _itemList.AddItem(toAdd.ItemName);
        _itemNamePanel.Hide();
    }

    public void Refresh()
    {
        _itemList.Clear();
        foreach (var item in _items)
        {
            _itemList.AddItem(item.Key);
        }
    }

    void OkButtonPressed() => CreateNewItem();
    void CancelButtonPressed() => _itemNamePanel.Hide();

    void NameEdit(string val)
    {
        var old = _currentItem.ItemName;
        _currentItem.ItemName = val;
        _items.Remove(old);
        _items.Add(_currentItem.ItemName, _currentItem);
        Refresh();
    }

    public void DescEdit(string desc) => _currentItem.SetItemDescription = desc;

    public void Save_Button()
    {
        json.Write("res://Assets/Data/Items.json", _items);
    }

    public bool Load() => json.Read("res://Assets/Data/Items.json", ref _items);

    public override void _ExitTree()
    {
        _itemList.Clear();
        _items.Clear();
        _save.Pressed -= Save_Button;
        _newItem.Pressed -= NewItem_Button;

        _itemName.TextChanged -= NameEdit;
        _itemDesc.TextChanged -= DescEdit;
        _itemList.ItemClicked -= ItemSelected;

        _okButton.Pressed -= OkButtonPressed;
        _cancelButton.Pressed -= CancelButtonPressed;
        base._ExitTree();
    }
}
#endif
