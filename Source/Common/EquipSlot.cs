public partial class EquipSlot : Node
{
    private SlotType _slot;
    private Equipable _equipment;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void Equip(SlotType s, Equipable e)
    {
        _slot = s;
        _equipment = e;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
