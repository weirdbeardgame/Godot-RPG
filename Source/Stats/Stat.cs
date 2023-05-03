namespace RPG;

public partial class Stat : Node
{
    private float _stat;

    // We put stat name in here for display purposes.
    // Player Data structure should hold its own string for this
    private string _statName;

    private Buff _buff;

    public void CreateStats(string Name, float Stats)
    {
        _statName = Name;
        _stat = Stats;
    }

    // Return name and Value
    public override string ToString()
    {
        return _statName + ": " + _stat.ToString();
    }

    public float GetStat
    {
        get
        {
            return _stat;
        }
    }

    public void Increase(float modifier)
    {
        _stat += modifier;
    }

    public void Decrease(float modifier)
    {
        if (_stat >= modifier)
        {
            _stat -= modifier;
        }
    }
}
