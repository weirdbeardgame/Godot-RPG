using Godot;

public enum LivingStatus { ALIVE, DEAD };

// A Class to be inherited from. Creatures are units stats.
public partial class Creature : Resource
{
    // Stats are objects that can be dynamically constructed and set!
    protected Godot.Collections.Dictionary<string, Stat> Stats;
    protected LivingStatus IsAlive;

    // Weapon Slots
    protected List<EquipSlot> Slots;
    protected string CeatureName;
    protected float ExpReqForLevelUp;
    protected float Experience;
    protected int Level;

    // Enemies and Players can be assigned a job. In other Rpg types, this would be class type
    JobSystem Job;

    public Godot.Collections.Dictionary<string, Stat> GetStats => Stats;

    public void CreateWeaponSlots()
    {
        Slots ??= new List<EquipSlot>();
        for (int i = 0; i < 5; i++)
        {
            Slots.Add(new EquipSlot((SlotType)i));
        }
    }

}
