namespace RPG;

public partial class EquipSlot : Node
{
    private SlotType _slot;
    private string SlotName;
    private bool HasEquipped;
    private Equipable _equipment;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public EquipSlot(SlotType s)
    {
        _slot = s;
        HasEquipped = false;
        SlotName = s.ToString();
    }

    public void Equip(Equipable e)
    {
        _equipment = e;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
