using System;
using System.Collections;
using Core.Items;
using Godot;

public partial class Player : Creature
{

    public void Init()
    {
        // ToDo: Load all state and other info from file.
        IsAlive = LivingStatus.ALIVE;
    }

    public void Equip(Equipable e)
    {
        foreach (var slot in Slots)
        {
            if (slot.CanBeEquipped(e, e.Job))
            {
                slot.Equip(e, e.Job);
            }
        }
    }

    public void Die()
    {
        if (Stats["Health"].CurrentStat == 0)
        {
            IsAlive = LivingStatus.DEAD;
        }
    }

    public void LevelUp()
    {
        // Just some filler code, this should be more complicated
        if (Experience >= ExpReqForLevelUp)
        {
            Level += 1;
            // Increase ExpReqForLevelUp, increase stats based on JobType and any other desired factors
            // Need growth curve

        }
    }

}
