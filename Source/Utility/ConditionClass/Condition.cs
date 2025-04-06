using Godot;
using System;

[GlobalClass]
public abstract partial class Condition : Resource
{
    public abstract bool CheckCondition();
}