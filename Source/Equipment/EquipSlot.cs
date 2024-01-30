namespace RPG;

public partial class EquipSlot : Node
{
    private SlotType _slot;
    private string SlotName;
    private bool HasEquipped;
    private Equipable _Equipment;
    public Equipable Equipped
    {
        get
        {
            if (HasEquipped)
            {
                return _Equipment;
            }
            return null;
        }
    }

    public EquipSlot(SlotType s)
    {
        _slot = s;
        HasEquipped = false;
        SlotName = s.ToString();
    }

    public void Equip(Equipable e, JobSystem Job)
    {
        // Only allow Equipment that fits the Job type.
        // Mages wouldn't use a sword for instance
        if (e.Job == Job)
        {
            _Equipment = e;
        }
    }
}
