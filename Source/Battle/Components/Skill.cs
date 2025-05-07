using Godot;
using System;

public enum SkillType { HEALING, DAMAGE }

public partial class Skill : Resource
{
    public string Name;
    public string Description;
    public Stat StatAffected;
    public Stat Effect;
    public List<Creature> Targets;
    public SkillType Type;

    [Export] public string Formula;
    private Expression _expression;

    public void Use()
    {
        foreach (var target in Targets)
        {
            if (target.GetStats.ContainsKey(StatAffected.StatName))
            {
                // Refractor eventually:
                // This uses two stat's. StatAffected, to select the Stat we're changing.
                // Effect, the actual effect stat. That could be damage, or any other effecting type of stat.
                target.GetStats[StatAffected.StatName].CurrentStat = (float)_expression.Execute([target.GetStats[StatAffected.StatName].CurrentStat, Effect.CurrentStat]);
            }
        }
    }
}
