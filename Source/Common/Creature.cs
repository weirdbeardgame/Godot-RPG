

public enum LivingStatus { ALIVE, DEAD };

// A Class to be inherited from. Creatures are units stats.
public partial class Creature : Node
{
    // Stats are objects that can be dynamically constructed and set!
    protected Dictionary<string, StatData> _stats;

    protected LivingStatus IsAlive;

    // Weapon Slots
    protected List<EquipSlot> _slots;
    protected string CeatureName;

    protected float ExpReqForLevelUp;
    protected float Experience;

    // Enemies and Players can be assigned a job. In other Rpg types, this would be class type
    JobSystem Job;

    // Can be used for UI in 3D games, or 2d games can be used for general world stuffs
    Sprite2D sprite;

    public override void _Ready()
    {
    }

    public void CreateWeaponSlots()
    {
        _slots ??= new List<EquipSlot>();
        for (int i = 0; i < 5; i++)
        {
            _slots.Add(new EquipSlot((SlotType)i));
        }
    }

    public override void _Process(double delta)
    {
    }
}
