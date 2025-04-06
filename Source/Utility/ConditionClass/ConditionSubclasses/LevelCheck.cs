using Godot;
using System;

[GlobalClass]
public partial class LevelCheck : Condition
{
    private enum CheckType{Threshold, Limit}
    [Export] CheckType Type = CheckType.Threshold;

    // placeholder below, if character stats are stored in resources we need resource export instead
    [Export] public string Character; 
    [Export] public int TargetLevel;
    
    
    public override bool CheckCondition()
    {
        switch (Type)
        {
            case CheckType.Threshold:
                // if Character.level < TargetLevel return true, else return false
                return false;


            case CheckType.Limit:
                // if Character.level > TargetLevel return false, else return true
                return false;


            default:
                return false;
        }

    }
}
