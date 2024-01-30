namespace RPG;

public enum SlotType { LARM, RARM, BODY, HEAD }

public partial class Equipable : Node
{
    protected Dictionary<string, Stat> WeaponStats;
    protected string WeaponName;
    protected int WeaponID;
    Sprite2D icon;
    SlotType type;

    // To check if weapon can actually be equipped by the Job Type
    public JobSystem Job;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public virtual void Attack()
    {

    }

    public virtual void Defend()
    {

    }

}
