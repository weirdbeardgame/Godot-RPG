using Godot;
using System;

namespace Core.Quests;

// All Quest logic should be written here
public partial class QuestManager : Node
{   
    public enum MoveQuestType
    {
        COPY,
        MOVE
    }

    private Dictionary<string, Quest> _quests;

    private Quest _activeQuest;

    public Quest ActiveQuest => _activeQuest;

    public override void _Ready()
    {
        base._Ready();

        _quests = new Dictionary<string, Quest>();

        // ToDo, load Quest Database
    }


    // Quest updating
    public void TryCompletingQuest(Quest quest) { }

    public void ForceCompleteQuest(Quest quest) { }

    public void UpdateQuest(Quest quest) { }

    public void UpdateQuestInArray(Godot.Collections.Array<Quest> listOfQuests) { }

    public void FailQuest(Quest quest) { }

    public void ForceFailQuest(Quest quest) { }

    public void AbandonQuest(Quest quest) { }

    // QuestDatabase handling
    public void RemoveQuest(Quest quest, Godot.Collections.Array<Quest> _from) { }

    public void RemoveQuests(Godot.Collections.Array<Quest> questsToRemove, Godot.Collections.Array<Quest> _from) { }

    public void ShiftQuestToArray(Quest quest, Godot.Collections.Array<Quest> _from, Godot.Collections.Array<Quest> _to, MoveQuestType moveType) { }

    public void CleanupTemporaryLists() { }

    // Batching Logic
    public void BatchUpdateQuest(Godot.Collections.Array<Quest> listOfQuests) { }

    public void BatchRemoveQuest(Godot.Collections.Array<Quest> quests, Godot.Collections.Array<Quest> _from) { }

    public void BatchShiftQuests(Godot.Collections.Array<Quest> quests, Godot.Collections.Array<Quest> from, Godot.Collections.Array<Quest> to, MoveQuestType moveType) { }

}