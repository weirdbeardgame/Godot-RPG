// A Class to be inherited from. Creatures are units stats.
public partial class Creature : Node
{
    // Stats are objects that can be dynamically constructed and set!
    protected List<Stat> Stats;
    protected List<EquipSlot> Slots;
    protected string CreatureName;
    protected float Experience;

    // Can be used for UI in 3D games, or 2d games can be used for general world stuffs
    Sprite2D sprite;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }
}
