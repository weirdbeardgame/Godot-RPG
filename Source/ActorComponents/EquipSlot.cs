

public partial class EquipSlot : Node
{
    private SlotType _slot;
    private string _slotName;
    private bool _hasEquipped;
    private Equipable _equipment;
    public Equipable Equipped
    {
        get
        {
            if (_hasEquipped)
            {
                return _equipment;
            }
            return null;
        }
    }

    public bool CanBeEquipped(Equipable e, JobSystem j) => e.Type == _slot && e.Job == j;

    public EquipSlot(SlotType s)
    {
        _slot = s;
        _hasEquipped = false;
        _slotName = s.ToString();
    }

    public void Equip(Equipable e, JobSystem Job)
    {
        // Only allow Equipment that fits the Job type and the slot type should equip.
        // Mages wouldn't use a sword for instance, and you wouldn't have a helmet on your arm.
        if (CanBeEquipped(e, Job))
        {
            _equipment = e;
            _hasEquipped = true;
        }
    }
}
