using System;
using System.Collections;
using Core.Items;
using Godot;

public partial class Player : Creature
{

    public void Equip(Equipable e)
    {
        foreach (var slot in _slots)
        {
            if (slot.CanBeEquipped(e, e.Job))
            {
                slot.Equip(e, e.Job);
            }
        }
    }

    public void Die()
    {
        if (_stats["Health"].Stat == 0)
        {
            IsAlive = LivingStatus.DEAD;
        }
    }

    public void LevelUp()
    {
        // Just some filler code, this should be more complicated
        if (Experience >= ExpReqForLevelUp)
        {

        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
