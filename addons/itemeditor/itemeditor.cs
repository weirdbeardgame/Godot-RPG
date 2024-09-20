#if TOOLS
using Godot;
using System;
using System.Linq;

[Tool]
public partial class itemeditor : EditorPlugin
{
    Button Save;
    Button NewItem;
    LineEdit ItemName;
    TextEdit ItemDesc;
    ImagePicker ItemIcon;

    [Export]
    Godot.Collections.Dictionary<string, EditorItem> _Items;
    List<string> ItemNames;

    Item CurSelected;

    BoxContainer ItemContainer;
    Control PanelInstance;
    PackedScene ItemButton;


    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {
        PackedScene ItemEditorControlScene = ResourceLoader.Load<PackedScene>("res://addons/itemeditor/Item Editor.tscn");
        PanelInstance = ItemEditorControlScene.Instantiate<Control>();

        ItemButton = ResourceLoader.Load<PackedScene>("res://Assets/GuiElements/EditorItem/EditorItem.tscn");

        ItemContainer = PanelInstance.GetNode<BoxContainer>("Editor/Items/ItemContainer");

        GetEditorInterface().GetEditorMainScreen().AddChild(PanelInstance);

        // Hide the main panel. Very much required.
        _MakeVisible(false);

        Save = PanelInstance.GetNode<Button>("Editor/Save");
        NewItem = PanelInstance.GetNode<Button>("Editor/New Item");
        ItemName = PanelInstance.GetNode<LineEdit>("Editor/ItemNameField");
        ItemDesc = PanelInstance.GetNode<TextEdit>("Editor/Description");
        //ItemIcon = (ImagePicker)PanelInstance.GetNode<Control>("Editor/ItemIcon");

        Save.Pressed += Save_Button;
        NewItem.Pressed += NewItem_Button;

        ItemName.TextChanged += NameEdit;
        ItemDesc.TextChanged += DescEdit;
        //ItemIcon.ImageChanged += UpdateImage;

        _Items = new Godot.Collections.Dictionary<string, EditorItem>();
    }


    public override bool _HasMainScreen()
    {
        return true;
    }

    public override void _MakeVisible(bool visible)
    {
        if (PanelInstance != null)
        {
            PanelInstance.Visible = visible;
        }
    }

    public void NewItem_Button()
    {
        EditorItem item = ItemButton.Instantiate<EditorItem>();
        Item toAdd = new Item(_Items.Count, Operator.ADD, "Item: " + _Items.Count, "Default");
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
    public void DescEdit() => CurSelected.SetItemDescription = ItemDesc.Text;
    public void UpdateImage(string P) => CurSelected.SetIconPath = P;

    public void Save_Button()
    {
        foreach (var Item in _Items)
        {
            ResourceSaver.Save(Item.Value.Object, "Res://Data/Items/" + Item.Key + ".tres");
        }
    }

    public override string _GetPluginName()
    {
        return "Items Editor";
    }

    public override Texture2D _GetPluginIcon()
    {
        // Must return some kind of Texture for the icon.
        return GetEditorInterface().GetEditorTheme().GetIcon("Node", "EditorIcons");
    }
}
#endif
