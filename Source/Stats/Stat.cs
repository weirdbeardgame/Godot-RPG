using Godot;
using System.Text.Json.Serialization;

public partial class StatData
{

    private float _maxStat;
    private float _stat;
    private string _statName;
    //private Buff _buff;

    public Guid ID { get; set; }

    public StatData()
    {
        _statName = "";
        _stat = 0.0f;
        ID = Guid.NewGuid();
    }

    public StatData(string Name, float stat)
    {
        _statName = Name;
        _maxStat = stat;
        ID = Guid.NewGuid();
    }

    public float MaxStat
    {
#if TOOLS // Note we only allow direct set in the editor, ingame updates should happen with operators
        set
        {
            _maxStat = value;
        }
#endif
        get
        {
            return _maxStat;
        }
    }

    public float Stat
    {
#if TOOLS // Note we only allow direct set in the editor, ingame updates should happen with operators
        set
        {
            _stat = value;
        }
#endif
        get
        {
            return _stat;
        }
    }
    public string StatName
    {

#if TOOLS
        set
        {
            _statName = value;
        }
#endif

        get
        {
            return _statName;
        }
    }
    // Return name and Value
    public override string ToString() => _statName + ": " + _stat.ToString();

    // Set of Operators for Stat math
    public static bool operator >(StatData s1, StatData s2) => s1.Stat > s2.Stat;

    public static bool operator <(StatData s1, StatData s2) => s1.Stat < s2.Stat;

    public static StatData operator +(StatData s1, StatData s2) => new(s1.StatName, s1.Stat + s2.Stat);

    public static StatData operator -(StatData s1, StatData s2) => new(s1.StatName, s1.Stat - s2.Stat);

    public static StatData operator /(StatData s1, StatData s2) => new(s1.StatName, s1.Stat / s2.Stat);

    public static StatData operator %(StatData s1, StatData s2) => new(s1.StatName, s1.Stat % s2.Stat);
}

