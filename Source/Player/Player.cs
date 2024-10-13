using System;
using System.Collections;
using Core.Items;
using Godot;



public partial class Player : Creature
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

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

	}

	public void LevelUp()
	{

	}

	public void RecieveItem(Item it)
	{

	}

	public void UseItem(Item it)
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
