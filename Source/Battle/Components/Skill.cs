using Godot;
using System;

public enum SkillType { HEALING, DAMAGE }

public partial class Skill : Resource
{
    public string Name;
    public string Description;
    public Stat StatAffected;
    public Stat Effect;
    public Creature Target;
    public SkillType Type;

    [Export] public string Formula;
    private Expression _expression;

    public void Use()
    {
        if (Target.GetStats.ContainsKey(StatAffected.StatName))
        {
            Target.GetStats[StatAffected.StatName].CurrentStat = (float)_expression.Execute([Target.GetStats[StatAffected.StatName].CurrentStat, Effect.CurrentStat]);
        }
    }
}
