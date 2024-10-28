using System;
using Core.Items;
using Godot;

public partial class HealingItem : Item
{
    public Dictionary<string, Stat> Stats;

    public HealingItem()
    {
        _operation = Operator.ADD;
    }

    public override bool Use()
    {
        foreach (var stat in _statsAffected)
        {
            if (Stats.ContainsKey(stat.Key))
            {
                Stats[stat.Key] += stat.Value;
                return true;
            }
        }
        return false;
    }
};