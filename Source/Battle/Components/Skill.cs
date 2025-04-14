using Godot;
using System;

public enum SkillType { HEALING, DAMAGE }

public partial class Skill : Resource
{
    public string Name;
    public string Description;
    public Dictionary<string, Stat> Stats;
    public Creature Target;

    public SkillType Type;

    [Export] public string Formula;
    private Expression _expression;

    public void Use()
    {
        foreach (var stat in Target.GetStats)
        {
            if (Stats.ContainsKey(stat.Key))
            {
                stat.Value.CurrentStat = (float)_expression.Execute([stat.Value.CurrentStat, Stats[stat.Key].CurrentStat]);
            }
        }
    }
}
