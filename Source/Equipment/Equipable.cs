

public enum SlotType { LARM, RARM, BODY, HEAD }

public partial class Equipable : Node
{
    protected Dictionary<string, Stat> _weaponStats;
    protected string _weaponName;
    protected int _weaponID;
    private Sprite2D _icon;
    private SlotType _type;
    private JobSystem _job;

    // To check if weapon can actually be equipped by the Job Type
    public JobSystem Job => _job;

    public SlotType Type => _type;

    public virtual void Attack()
    {

    }

    public virtual void Defend()
    {

    }

}
