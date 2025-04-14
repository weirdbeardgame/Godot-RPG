using Godot;

// Note, due to Stat being a resource. JSON and the previous editor will be broken
public partial class Stat : Resource
{

    private float _maxStat;
    private float _stat;
    private string _statName;
    //private Buff _buff;

    public Guid ID { get; set; }

    public Stat()
    {
        _statName = "";
        _stat = 0.0f;
        ID = Guid.NewGuid();
    }

    public Stat(string Name, float stat)
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

    public float CurrentStat
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
    public static bool operator >(Stat s1, Stat s2) => s1.CurrentStat > s2.CurrentStat;

    public static bool operator <(Stat s1, Stat s2) => s1.CurrentStat < s2.CurrentStat;

    public static Stat operator +(Stat s1, Stat s2) => new(s1.StatName, s1.CurrentStat + s2.CurrentStat);

    public static Stat operator -(Stat s1, Stat s2) => new(s1.StatName, s1.CurrentStat - s2.CurrentStat);

    public static Stat operator /(Stat s1, Stat s2) => new(s1.StatName, s1.CurrentStat / s2.CurrentStat);

    public static Stat operator %(Stat s1, Stat s2) => new(s1.StatName, s1.CurrentStat % s2.CurrentStat);
}

