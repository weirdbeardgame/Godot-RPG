using Godot;
using System;

namespace Core.Quests;

[Tool]
public partial class QuestEditor : Node
{
    Button _NewQuest;
    QuestManager _Manager;

    List<Button> QuestList;
    List<string> QuestNames;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        QuestNames = new List<string>();
        QuestList = new List<Button>();
        _NewQuest = GetNode<Button>("NewQuest");
        _NewQuest.Pressed += NewQuest_Button;
    }

    public void NewQuest_Button()
    {
        _Manager.NewQuest();
    }

    public void Update()
    {

    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
