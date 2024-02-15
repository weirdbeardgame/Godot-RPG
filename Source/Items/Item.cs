using Godot;
using System;

public enum Operator { ADD, SUBTRACT, DIVIDE, MODULO };

public partial class Item : Resource
{
    [Export]
    int _ID;
    [Export]
    Operator _Operation;
    [Export]
    string _ItemName;
    [Export]
    string _ItemDescription;

    // Uncomment for weight based Inventory system
    // [Export]
    // int _ItemWeight;
    // public int ItemWeight => _ItemWeight;

    public string ItemName => _ItemName;

    // The Stats this item applies too.
    Dictionary<string, Stat> StatsAffected;

    public Item()
    {

    }

    // Note that in this instance, ID will always be the max count
    public Item(int id, Operator itemType, string name, string desc)
    {

    }


    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(ref Dictionary<string, Stat> Stats)
    {
        switch (_Operation)
        {
            case Operator.ADD:
                foreach (var Stat in StatsAffected)
                {
                    if (Stats.ContainsKey(Stat.Key))
                    {
                        Stats[Stat.Key] += Stat.Value;
                        return true;
                    }
                    return false;
                }
                break;

            case Operator.SUBTRACT:
                foreach (var Stat in StatsAffected)
                {
                    if (Stats.ContainsKey(Stat.Key))
                    {
                        Stats[Stat.Key] -= Stat.Value;
                        return true;
                    }
                    return false;
                }
                break;

            case Operator.DIVIDE:
                foreach (var Stat in StatsAffected)
                {
                    if (Stats.ContainsKey(Stat.Key))
                    {
                        Stats[Stat.Key] /= Stat.Value;
                        return true;
                    }
                    return false;
                }
                break;

            case Operator.MODULO:
                foreach (var Stat in StatsAffected)
                {
                    if (Stats.ContainsKey(Stat.Key))
                    {
                        Stats[Stat.Key] %= Stat.Value;
                        return true;
                    }
                    return false;
                }
                break;
        }
        return true;
    }
}
