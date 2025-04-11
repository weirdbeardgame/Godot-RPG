using Godot;
using System;
using Core.Items;

[GlobalClass]
public abstract partial class Reward : Resource
{
    public abstract void GiveReward();
}
