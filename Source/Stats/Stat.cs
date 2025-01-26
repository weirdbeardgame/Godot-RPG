using Godot;
using System;

public partial class Stat : Resource
{

    private float _maxStat;
    private float _stat;

    // We put stat name in here for display purposes.
    // Player Data structure should hold its own string for this
    private string _statName;
    private Buff _buff;

    public Guid ID;

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
            if (_maxStat < 0)
            {
                return 0;
            }
            return _maxStat;
        }
    }

    public float GetStat
    {
#if TOOLS // Note we only allow direct set in the editor, ingame updates should happen with operators
        set
        {
            _stat = value;
        }
#endif
        get
        {
            if (_stat < 0)
            {
                return 0;
            }
            return _stat;
        }
    }
    public string StatName => _statName;

    // Return name and Value
    public override string ToString() => _statName + ": " + _stat.ToString();

    // Set of Operators for Stat math
    public static bool operator >(Stat s1, Stat s2) => s1.GetStat > s2.GetStat;

    public static bool operator <(Stat s1, Stat s2) => s1.GetStat < s2.GetStat;

    public static Stat operator +(Stat s1, Stat s2) => new(s1.StatName, s1.GetStat + s2.GetStat);

    public static Stat operator -(Stat s1, Stat s2) => new(s1.StatName, s1.GetStat - s2.GetStat);

    public static Stat operator /(Stat s1, Stat s2) => new(s1.StatName, s1.GetStat / s2.GetStat);

    public static Stat operator %(Stat s1, Stat s2) => new(s1.StatName, s1.GetStat % s2.GetStat);
}

