

public partial class EquipSlot : Node
{
    private SlotType _Slot;
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

    public bool CanBeEquipped(Equipable e, JobSystem j)
    {
        return (e.Type == _Slot && e.Job == j);
    }

    public EquipSlot(SlotType s)
    {
        _Slot = s;
        HasEquipped = false;
        SlotName = s.ToString();
    }

    public void Equip(Equipable e, JobSystem Job)
    {
        // Only allow Equipment that fits the Job type and the slot type should equip.
        // Mages wouldn't use a sword for instance, and you wouldn't have a helmet on your arm.
        if (CanBeEquipped(e, Job))
        {
            _Equipment = e;
            HasEquipped = true;
        }
    }
}
