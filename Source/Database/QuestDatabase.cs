using Godot;
using System;
using Core.Quests;

// No methods to be added here, Logic will be inside QuestManager Class
public partial class QuestDatabase
{
    // Stable Lists
    public Godot.Collections.Array<Quest> AllQuests;

    public Godot.Collections.Array<Quest> AvailableQuests;
    public Godot.Collections.Array<Quest> ActiveQuests;
    public Godot.Collections.Array<Quest> InactiveQuests;

    public Godot.Collections.Array<Quest> UnavailableQuests;

    public Godot.Collections.Array<Quest> TrackedQuests;
    public Godot.Collections.Array<Quest> FailedQuests;
    public Godot.Collections.Array<Quest> AbandonedQuests;

    public Godot.Collections.Array<Quest> QuestsEnemyKilling;
    public Godot.Collections.Array<Quest> QuestsItemGathering;
    public Godot.Collections.Array<Quest> QuestsAchievementTracking;


    // Temporary Lists - Used for one-frame or short-lived checks
    public Godot.Collections.Array<Quest> RecentlyProgressedQuests;
}