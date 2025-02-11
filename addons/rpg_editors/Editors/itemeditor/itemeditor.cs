#if TOOLS
using Godot;
using System;
using System.Linq;
using Core.Items;

[Tool]
public partial class itemeditor : Control
{
    Button Save;
    Button NewItem;
    LineEdit ItemName;
    LineEdit ItemDesc;
    ImagePicker ItemIcon;

    [Export]
    Godot.Collections.Dictionary<string, EditorItem> _Items;
    List<string> ItemNames;

    Item CurSelected;

    BoxContainer ItemContainer;
    PackedScene ItemButton;

    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {

        //Save = PanelInstance.GetNode<Button>("Save");
        NewItem = GetNode<Button>("VSplitContainer/ItemListButtons/AddItem");
        ItemName = GetNode<LineEdit>("Control/VBoxContainer/ItemNameField");
        ItemDesc = GetNode<LineEdit>("Control/VBoxContainer/Description");
        //ItemIcon = GetNode<ImagePicker>("Control/VSplitContainer/ItemIcon");

        //Save.Pressed += Save_Button;
        //NewItem.Pressed += NewItem_Button;

        ItemName.TextChanged += NameEdit;
        ItemDesc.TextChanged += DescEdit;
        //ItemIcon.ImageChanged += UpdateImage;

        _Items = new Godot.Collections.Dictionary<string, EditorItem>();
    }

    public void NewItem_Button()
    {
        EditorItem item = ItemButton.Instantiate<EditorItem>();
        Item toAdd = new Item(Operator.ADD, "Item: " + _Items.Count, "Default");
        item.CreateButton(toAdd.ItemName, toAdd);
        _Items.Add(toAdd.ItemName, item);
        CurSelected = toAdd;

        ItemContainer.AddChild(item);
        UpdateItemList();
    }

    void UpdateItemList()
    {
        if (ItemNames != null && ItemNames != _Items.Keys.ToList<string>())
        {
            ItemNames = _Items.Keys.ToList<string>();
        }
    }

    public void NameEdit(string N) => CurSelected.SetItemName = N;
    public void DescEdit(string desc) => CurSelected.SetItemDescription = desc;
    //public void UpdateImage(string P) => CurSelected.SetIconPath = P;

    public void Save_Button()
    {
        foreach (var Item in _Items)
        {
            ResourceSaver.Save(Item.Value.Object, "Res://Data/Items/" + Item.Key + ".tres");
        }
    }
}
#endif
