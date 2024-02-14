using Godot;
using System;

enum ItemType { BUFF, DEBUFF };

public partial class Item : Resource
{
    int _ID;
    string _ItemName;
    ItemType _Type;

    // Uncomment for weight based Inventory system
    // int _ItemWeight;
    // public int ItemWeight => _ItemWeight;

    public string ItemName => _ItemName;

    // The Stats this item applies too.
    Dictionary<string, Stat> StatsAffected;

    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(ref Dictionary<string, Stat> Stats)
    {
        switch (_Type)
        {
            case ItemType.BUFF:
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

            case ItemType.DEBUFF:
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
        }

        return true;
    }
}
