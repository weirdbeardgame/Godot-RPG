using Godot;
using System;

namespace Core.Quests;

public partial class QuestRequirement : Node
{
    [Export]
    protected int _amt;

    [Export]
    protected string reqName;
}
