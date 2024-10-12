using Godot;
using System;

[Tool]
public partial class QuestManager : Node
{
    private Dictionary<string, Quest> _quests;

    private Quest _activeQuest;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

#if TOOLS

    public override void _EnterTree()
    {
        _quests = new Dictionary<string, Quest>();
    }

    public void NewQuest()
    {
        Quest Q = new Quest("Quest " + _quests.Count.ToString(), "Default");
        _quests.Add(Q.QuestName, Q);
    }
#endif

    public bool ActivateQuest(string QuestName)
    {
        Quest Temp;
        if ((Temp = _quests[QuestName]) != null)
        {
            if (_activeQuest != Temp)
            {
                _activeQuest.Stop();
                _activeQuest = Temp;
                return _activeQuest.Start();
            }
        }

        return false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
