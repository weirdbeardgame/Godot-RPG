using Godot;
using System;

public partial class Enemy : Creature
{
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
        if (Stats["Health"].Stat == 0)
        {
            IsAlive = LivingStatus.DEAD;
        }
    }
}
