using Godot;
using System;

public enum SkillType { HEALING, DAMAGE }

public partial class Skill : Resource
{
    public string Name;
    public string Description;
    public Dictionary<string, StatData> Stats;
    public Creature Target;

    public SkillType Type;

    // ToDo: Define and apply formula
    public void Use()
    {

        switch (Type)
        {
            case SkillType.DAMAGE:
                foreach (var stat in Target.GetStats)
                {
                    if (Stats.ContainsKey(stat.Key))
                    {
                        stat.Value.Stat -= Stats[stat.Key].Stat;
                    }
                }
                break;

            case SkillType.HEALING:
                foreach (var stat in Target.GetStats)
                {
                    if (Stats.ContainsKey(stat.Key))
                    {
                        stat.Value.Stat += Stats[stat.Key].Stat;
                    }
                }
                break;
        }
    }
}
