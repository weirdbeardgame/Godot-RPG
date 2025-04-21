using Godot;

public enum LivingStatus { ALIVE, DEAD };

// A Class to be inherited from. Creatures are units stats.
public partial class Creature : Resource
{
    // Stats are objects that can be dynamically constructed and set!
    protected Godot.Collections.Dictionary<string, Stat> Stats;
    protected LivingStatus IsAlive;

    // Weapon Slots
    private List<EquipSlot> _slots;

    // Need to account for Level Curves
    protected float ExpReqForLevelUp;
    protected float Experience;
    protected int Level;

    public string Name;

    public List<EquipSlot> Slots
    {
        get
        {
            return _slots;
        }
    }

    // Enemies and Players can be assigned a job. In other Rpg types, this would be class type
    protected JobSystem Job;

    public Godot.Collections.Dictionary<string, Stat> GetStats => Stats;

    public void CreateWeaponSlots()
    {
        _slots ??= new List<EquipSlot>();
        for (int i = 0; i < 5; i++)
        {
            _slots.Add(new EquipSlot((SlotType)i));
        }
    }

}
