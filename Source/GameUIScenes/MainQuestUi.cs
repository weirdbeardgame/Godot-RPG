using Godot;
using GodotPlugins.Game;
using System;
using System.Diagnostics;

public partial class MainQuestUi : Control
{
    [ExportGroup("Node Injection")]
    [Export] private Control QuestHeaderControl;
    [Export] private Control QuestConditionsControl;
    [Export] private Panel BGPanel;
    [Export] private Control ConditionTextControl;

    [ExportGroup("Label Injection")]
    [Export] private Label TitleLabel;
    [Export] private Label QuestDescriptionLabel;
    //[Export] private Label QuestConditionLabel;

    [ExportGroup("Size Manipulation")]
    [Export] private float HeaderYSize = 200f;
    [Export] private float ConditionDetailYSize = 1.0f;
    [Export] private float Spacing = 40f;

    public override void _Ready()
    {
        UpdateQuestText();
        AddConditionTexts(3);
        UpdateQuestUIPosition();
    }

    private void UpdateQuestText() 
    { 
        if (TitleLabel != null) { TitleLabel.Text = "Tracked Quest Title"; }
        if (QuestDescriptionLabel != null) { QuestDescriptionLabel.Text = "Tracked Quest Description"; }
    }

    private void UpdateQuestUIPosition() 
    { 
        QuestConditionsControl.Size = new Vector2(QuestHeaderControl.Size.X, ConditionDetailYSize * (QuestHeaderControl.Size.Y * QuestHeaderControl.Scale.Y));
        QuestConditionsControl.Position = new Vector2(QuestHeaderControl.Position.X, QuestHeaderControl.Position.Y + (QuestHeaderControl.Size.Y * QuestHeaderControl.Scale.Y) + Spacing); 
    }

    private void AddConditionTexts(int totalNumber)
    {
        float accumulatedSize = 0;
        for (int i = 0; i < totalNumber; i++)
        {
            Control newConditionText = (Control)ConditionTextControl.Duplicate();
            QuestConditionsControl.AddChild(newConditionText);

            newConditionText.Visible = true;
            newConditionText.Size = new Vector2(QuestHeaderControl.Size.X, ConditionDetailYSize * (QuestHeaderControl.Size.Y * QuestHeaderControl.Scale.Y));
            newConditionText.Position = new Vector2(0,accumulatedSize);

            accumulatedSize += newConditionText.Size.Y;
        }
    }
}
