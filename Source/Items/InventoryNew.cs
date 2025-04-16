using Core.Items;
using Godot;
using System;

public partial class InventoryNew : Node
{
    private Node inventoryHolder;

    [Export] private int maxSlots;
    private int usedSlots;

    public override void _Ready()
    {
        base._Ready();


    //  inventoryHolder = GetParent();
    // better way to do it would be the character injecting itself into the invHolder variable
    }

    public void UseItem(ItemNew ItemResource, String TargetCharacter) 
    { }

    private bool AddItem(ItemNew ItemResource) { return false; }
    private void RemoveItem(ItemNew ItemResource) { }
    private void RememberInventory() { }
 
    private void StackItem(ItemNew ItemResource) { }
    private void UseNewSlot(ItemNew ItemResource) { }

    public float CheckTotalValue() { return 0f; }
    public int HasItemQuantity(ItemNew ItemResource) { return 0; }
    public void IncreaseInventorySlots(int slotCount) { } 

    public void ClearInventory(bool Remember) { if (Remember) { RememberInventory(); } return; }
}
