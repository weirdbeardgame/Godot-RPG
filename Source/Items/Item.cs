using Godot;
using System;

public enum Operator { ADD, SUBTRACT, DIVIDE, MODULO };

public partial class Item : Resource
{
    [Export]
    private int _iD;
    [Export]
    private Operator _operation;
    [Export]
    private string _itemName;
    [Export]
    private string _itemDescription;

    [Export]
    private bool _consumeable;

    // The Stats this item applies too.
    [Export]
    private Godot.Collections.Dictionary<string, Stat> _statsAffected;

    // Uncomment for weight based Inventory system
    // [Export]
    // int _ItemWeight;
    // public int ItemWeight => _ItemWeight;

    public int ID => _iD;
    public string ItemName => _itemName;
    public Operator Operation => _operation;
    public bool Consumeable => _consumeable;
    public string ItemDescription => _itemDescription;



#if TOOLS
    public int SetID
    {
        set
        {
            _iD = value;
        }
    }
    public Operator SetOperation
    {
        set
        {
            _operation = value;
        }
    }

    public string SetItemName
    {
        set
        {
            _itemName = value;
        }
    }

    public string SetItemDescription
    {
        set
        {
            _itemDescription = value;
        }
    }

    public Godot.Collections.Dictionary<string, Stat> SetStatsAffected
    {
        set
        {
            _statsAffected = value;
        }
    }
#endif

    public Item()
    {

    }

    // Note that in this instance, ID will always be the max count
    public Item(int id, Operator itemType, string name, string desc)
    {
        _iD = id;
        _operation = itemType;
        _itemName = name;
        _itemDescription = desc;
    }

    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(ref Dictionary<string, Stat> stats)
    {
        if (_consumeable)
        {
            switch (_operation)
            {
                case Operator.ADD:
                    foreach (var stat in _statsAffected)
                    {
                        if (stats.ContainsKey(stat.Key))
                        {
                            stats[stat.Key] += stat.Value;
                            return true;
                        }
                        return false;
                    }
                    break;

                case Operator.SUBTRACT:
                    foreach (var stat in _statsAffected)
                    {
                        if (stats.ContainsKey(stat.Key))
                        {
                            stats[stat.Key] -= stat.Value;
                            return true;
                        }
                        return false;
                    }
                    break;

                case Operator.DIVIDE:
                    foreach (var stat in _statsAffected)
                    {
                        if (stats.ContainsKey(stat.Key))
                        {
                            stats[stat.Key] /= stat.Value;
                            return true;
                        }
                        return false;
                    }
                    break;

                case Operator.MODULO:
                    foreach (var stat in _statsAffected)
                    {
                        if (stats.ContainsKey(stat.Key))
                        {
                            stats[stat.Key] %= stat.Value;
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
