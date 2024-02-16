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

    [Export]
    bool _Consumeable;

    // The Stats this item applies too.
    [Export]
    Godot.Collections.Dictionary<string, Stat> _StatsAffected;

    // Uncomment for weight based Inventory system
    // [Export]
    // int _ItemWeight;
    // public int ItemWeight => _ItemWeight;

    public int ID => _ID;
    public string ItemName => _ItemName;
    public Operator Operation => _Operation;
    public bool Consumeable => _Consumeable;
    public string ItemDescription => _ItemDescription;



#if TOOLS
    public int SetID
    {
        set
        {
            _ID = value;
        }
    }
    public Operator SetOperation
    {
        set
        {
            _Operation = value;
        }
    }

    public string SetItemName
    {
        set
        {
            _ItemName = value;
        }
    }

    public string SetItemDescription
    {
        set
        {
            _ItemDescription = value;
        }
    }

    public Godot.Collections.Dictionary<string, Stat> SetStatsAffected
    {
        set
        {
            _StatsAffected = value;
        }
    }
#endif

    public Item()
    {

    }

    // Note that in this instance, ID will always be the max count
    public Item(int id, Operator itemType, string name, string desc)
    {
        _ID = id;
        _Operation = itemType;
        _ItemName = name;
        _ItemDescription = desc;
    }

    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(ref Dictionary<string, Stat> Stats)
    {
        if (_Consumeable)
        {
            switch (_Operation)
            {
                case Operator.ADD:
                    foreach (var Stat in _StatsAffected)
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
                    foreach (var Stat in _StatsAffected)
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
                    foreach (var Stat in _StatsAffected)
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
                    foreach (var Stat in _StatsAffected)
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
        return false;
    }
}
