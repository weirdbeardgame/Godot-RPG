using System;
using Core.Items;
using Godot;

public partial class DamageItem : Item
{
    public Dictionary<string, Stat> Stats;

    public DamageItem()
    {
        _operation = Operator.SUBTRACT;
    }

    public override bool Use()
    {
        foreach (var stat in _statsAffected)
        {
            if (Stats.ContainsKey(stat.Key))
            {
                Stats[stat.Key] -= stat.Value;
                return true;
            }
        }
        return false;
    }
};