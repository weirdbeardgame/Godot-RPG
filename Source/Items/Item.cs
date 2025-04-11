using Godot;
using System;

namespace Core.Items;

// These are to define a small equation scripting language if so desired.
// But they may remain unused, and direct coding operators used instead for flexibility sake
public enum Operator { ADD, SUBTRACT, DIVIDE, MODULO };

// Note, due to Item being a resource, JSON and the previous editor will be broken
public partial class Item : Resource
{
    protected string _itemName;
    protected bool _consumeable;
    protected Operator _operation;
    protected string _itemDescription;
    public Guid ID { get; set; }

    // The Stats this item applies too.
    protected Godot.Collections.Dictionary<string, StatData> _statsAffected;

    // Uncomment for weight based Inventory system
    // private int _itemWeight;
    // public int ItemWeight => _itemWeight;

    public string ItemName
    {
#if TOOLS
        set
        {
            _itemName = value;
        }
#endif
        get
        {
            return _itemName;
        }
    }

    public Operator Operation => _operation;
    public bool Consumeable => _consumeable;
    public string ItemDescription
    {

#if TOOLS
        set
        {
            _itemDescription = value;
        }
#endif
        get
        {
            return _itemDescription;
        }
    }

#if TOOLS
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

    public Godot.Collections.Dictionary<string, StatData> SetStatsAffected
    {
        set
        {
            _statsAffected = value;
        }
    }
#endif

    // For some reason, Godot preferres a Default Constructor when Searializing.
    public Item()
    {

    }

    // Note that in this instance, ID will always be the max count
    public Item(Operator itemType, string name, string desc)
    {
        _operation = itemType;
        _itemName = name;
        _itemDescription = desc;
        ID = Guid.NewGuid();
    }

    public virtual bool Use()
    {
        return false;
    }

    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    /*public virtual bool Use(Dictionary<string, StatData> stats)
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
    }*/
}
