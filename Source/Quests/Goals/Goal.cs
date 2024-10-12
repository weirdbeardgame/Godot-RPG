using Godot;
using System;

public partial class Goal : Resource
{
    [Export] protected string _name;
    [Export] protected string _description;
    protected int _progress;

    [Export] public int RequiredProgress;

    public string Name => _name;
    public string Description => _description;

    public static Action<Item> ReportItemCollected;

    public virtual void Start()
    {

    }
    public virtual bool CheckIfCompleted(int Amount, Variant Goal) => false;

    public virtual void Stop()
    {

    }

    public virtual bool Complete()
    {
        return false;
    }
}
