

public enum SlotType { LARM, RARM, BODY, HEAD }

public partial class Equipable : Node
{
    protected Dictionary<string, Stat> WeaponStats;
    protected string WeaponName;
    protected int WeaponID;
    Sprite2D _Icon;
    SlotType _Type;
    JobSystem _Job;

    // To check if weapon can actually be equipped by the Job Type
    public JobSystem Job => _Job;

    public SlotType Type => _Type;

    public virtual void Attack()
    {

    }

    public virtual void Defend()
    {

    }

}
