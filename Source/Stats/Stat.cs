using Godot;

public partial class Stat : Resource
{
    private float _Stat;

    // We put stat name in here for display purposes.
    // Player Data structure should hold its own string for this
    private string _StatName;
    private Buff _buff;

    public Stat()
    {
        _StatName = "";
        _Stat = 0.0f;
    }

    public Stat(string Name, float Stat)
    {
        _StatName = Name;
        _Stat = Stat;
    }

    public float GetStat => _Stat;
    public string StatName => _StatName;

    // Return name and Value
    public override string ToString() => _StatName + ": " + _Stat.ToString();

    // Set of Operators for Stat math
    public static bool operator >(Stat s1, Stat s2) => s1.GetStat > s2.GetStat;

    public static bool operator <(Stat s1, Stat s2) => s1.GetStat < s2.GetStat;

    public static Stat operator +(Stat s1, Stat s2) => new Stat(s1.StatName, s1.GetStat + s2.GetStat);

    public static Stat operator -(Stat s1, Stat s2) => new Stat(s1.StatName, s1.GetStat - s2.GetStat);

    public static Stat operator /(Stat s1, Stat s2) => new Stat(s1.StatName, s1.GetStat / s2.GetStat);

    public static Stat operator %(Stat s1, Stat s2) => new Stat(s1.StatName, s1.GetStat % s2.GetStat);
}

