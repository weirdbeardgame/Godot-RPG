using Godot;
using RPG;
using System;

enum ItemType { BUFF, DEBUFF };

public partial class Item : Node
{
    int ID;
    string ItemName;
    ItemType type;
    // The Stats this item applies too.
    Dictionary<string, Stat> StatsAffected;


    // ToDo, add check if Buff or Debuff apply correctly. IE. Current stat is not too large or small
    public virtual bool Use(ref Dictionary<string, Stat> Stats)
    {
        switch (type)
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
