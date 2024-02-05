using Godot;
using System;

public partial class QuestRequirement : Node
{
    [Export]
    protected int Amt;

    [Export]
    protected string ReqName;

    public virtual bool Check(int Amount, Variant ToCheck) => false;
}

public partial class ItemRequired : QuestRequirement
{
    [Export]
    Item RequiredItem;

    public override bool Check(int Amount, Variant ToCheck) => (Item)ToCheck == RequiredItem && Amount <= Amt;
}

public partial class EnemiesRequired : QuestRequirement
{
    [Export]
    Enemy EnemyToDestroy;

    public override bool Check(int Amount, Variant ToCheck) => (Enemy)ToCheck == EnemyToDestroy && Amount <= Amt;
}

public partial class QuestRequired : QuestRequirement
{
    [Export]
    Quest NeededToHaveCompleted;

    public override bool Check(int Amount, Variant ToCheck) => (Quest)ToCheck == NeededToHaveCompleted;
}