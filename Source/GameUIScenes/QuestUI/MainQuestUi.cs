using Core.Quests;
using Godot;
using GodotPlugins.Game;
using System;
using System.Diagnostics;

public partial class MainQuestUi : Control
{
    [ExportGroup("Required Scenes")]
    [Export] private PackedScene ConditionTextControl;

    [ExportGroup("Node Injection")]
    [Export] private Control QuestHeaderControl;
    [Export] private Control AllConditionsControl;
    [Export] private Panel BGPanel;
    [Export] private Panel ConditionsBGPanel;

    [ExportGroup("Label Injection")]
    [Export] private Label TitleLabel;

    [ExportGroup("Size Manipulation")]
    [Export] private float HeaderLength = 200f;
    [Export] private float ConditionLengthRatio = 1.0f;

    public override void _Ready()
    {
        UpdateQuestUI(new Quest());
    }

    private void UpdateQuestUI(Quest quest) 
    {  
        // Testing Logic
        quest.Title = "My Custom Quest";
        TitleLabel.Text = quest.Title;

        for (int i = 0; i < 4; i++) { AddConditionControl(); }

        UpdateQuestConditions();
    }

    private void AddConditionControl()
    {
        Control newControl = (Control)ConditionTextControl.Instantiate();
        AllConditionsControl.AddChild(newControl);
    }

    private float GetTotalConditionControlLength()
    {
        float size = 0f;
        foreach(Control ConditionControl in  AllConditionsControl.GetChildren())
        {
            size = size + ConditionControl.Size.Y;
        }
        return size;
    }

    private void UpdateConditionsBG(float TotalLength) 
    {
        ConditionsBGPanel.Size = new Vector2(QuestHeaderControl.Size.X, TotalLength);
        ConditionsBGPanel.Position = new Vector2(ConditionsBGPanel.Position.X, QuestHeaderControl.Size.Y);
    }

    private void UpdateQuestConditions()
    {
        float QHX = QuestHeaderControl.Size.X;
        float QHY = QuestHeaderControl.Size.Y;

        float accumulatingY = 0;

        foreach(Control ConditionControl in AllConditionsControl.GetChildren())
        {
            ConditionControl.Size = new Vector2(QHX, QHY * ConditionLengthRatio);
            ConditionControl.Position = new Vector2(0, QHY + accumulatingY);

            accumulatingY += ConditionControl.Size.Y;
        }
        UpdateConditionsBG(accumulatingY);
    }

}

