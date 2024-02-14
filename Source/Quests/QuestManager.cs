using Godot;
using System;



[Tool]
public partial class QuestManager : Node
{
    Dictionary<string, Quest> Quests;

    Quest _ActiveQuest;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

#if TOOLS

    public override void _EnterTree()
    {
        Quests = new Dictionary<string, Quest>();
    }

    public void NewQuest()
    {
        Quest Q = new Quest("Quest " + Quests.Count.ToString(), "Default");
        Quests.Add(Q.QuestName, Q);
    }
#endif

    public bool ActivateQuest(string QuestName)
    {
        Quest Temp;
        if ((Temp = Quests[QuestName]) != null)
        {
            if (_ActiveQuest != Temp)
            {
                _ActiveQuest.Stop();
                _ActiveQuest = Temp;
                return _ActiveQuest.Start();
            }
        }

        return false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
