using Godot;
using System;

// Should probably make this a string for custom goal types



public partial class Goal : Node
{
    [Export]
    protected string GoalTitle;
    [Export]
    protected string Description;
    [Export]
    protected int AmtRequired;

    public string Title => GoalTitle;
    public string GoalDescription => Description;

    public virtual bool CheckIfCompleted(int Amount, Variant Goal) => false;
}


public partial class ItemCollect : Goal
{
    [Export]
    Item ItemToCollect;

    public override bool CheckIfCompleted(int Amount, Variant Goal) => (Item)Goal == ItemToCollect && Amount <= AmtRequired;

}

public partial class EnemyKill : Goal
{
    [Export]
    Enemy EnemyToKill;

    public override bool CheckIfCompleted(int Amount, Variant Goal) => (Enemy)Goal == EnemyToKill && Amount <= AmtRequired;

}