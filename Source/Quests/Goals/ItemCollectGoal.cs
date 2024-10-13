using Godot;
using System;
using Core.Items;

partial class ItemCollectGoal : Goal
{
    private Item _itemToCollect;

    public override void Start()
    {
        base.Start();
        ReportItemCollected += ItemCollected;
    }

    public override void Stop()
    {
        base.Stop();
    }

    public void ItemCollected(Item item)
    {

    }


    public override bool Complete()
    {
        return base.Complete();
    }

}