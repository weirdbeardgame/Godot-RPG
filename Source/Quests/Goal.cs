using Godot;
using System;

// Should probably make this a string for custom goal types
enum GoalTypes { COLLECT_ITEM, KILL_ENEMY }

public partial class Goal : Node
{
    private string _Name;
    private GoalTypes _Type;
    private string _Description;

    // Goal Properties

    Item NeededItemToCollect;
    // Enemy ToKill;


    public string GoalName => _Name;
    public string Description => _Description;

    public delegate bool CompleteHandler();
    public static event CompleteHandler Complete;


    void Start()
    {
        Complete += CheckIfCompleted;
    }

    bool CheckIfCompleted()
    {

        switch (_Type)
        {
            case GoalTypes.COLLECT_ITEM:

                break;

            case GoalTypes.KILL_ENEMY:

                break;
        }

        return false;
    }
}
