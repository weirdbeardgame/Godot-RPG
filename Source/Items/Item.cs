using Godot;
using System;


namespace Core.Items;

public enum Operator { ADD, SUBTRACT, DIVIDE, MODULO };

public partial class Item : Resource
{
    private string _id = new Guid().ToString();

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
    private Dictionary<string, Stat> _statsAffected;

    // Uncomment for weight based Inventory system
    // private int _itemWeight;
    // public int ItemWeight => _itemWeight;

    public string ID => _id;
    public string ItemName => _itemName;
    public Operator Operation => _operation;
    public bool Consumeable => _consumeable;
    public string ItemDescription => _itemDescription;



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

    public Dictionary<string, Stat> SetStatsAffected
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
    public Item(Operator itemType, string name, string desc)
    {
        _operation = itemType;
        _itemName = name;
        _itemDescription = desc;
    }

    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(Dictionary<string, Stat> stats)
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
