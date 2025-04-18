using Core.Items;
using Godot;
using System;

public partial class InventoryNew : Node
{
    private Node inventoryHolder; // the character/entity holding the inventory. Should be injected

    [Export] private int maxSlots;
    private int usedSlots;

    public override void _Ready()
    {
        base._Ready();
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
