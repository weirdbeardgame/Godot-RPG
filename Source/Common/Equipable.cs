namespace RPG;

public enum SlotType { LARM, RARM, BODY, HEAD }

public partial class Equipable : Node
{
    protected List<Stat> WeaponStats;
    protected string WeaponName;
    protected int WeaponID;

    SlotType type;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
