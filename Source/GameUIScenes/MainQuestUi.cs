using Godot;
using GodotPlugins.Game;
using System;
using System.Diagnostics;

public partial class MainQuestUi : Control
{
    [ExportGroup("Node Injection")]
    [Export] private Control QuestHeaderControl;
    [Export] private Control QuestDetailControl;
    [Export] private Panel QuestBGPanel;

    [ExportGroup("Label Injection")]
    [Export] private Label TitleLabel;
    [Export] private Label QuestDescriptionLabel;
    [Export] private Label QuestConditionLabel;

    [ExportGroup("Size Manipulation")]
    [Export] private float HeaderYSize = 200f;
    [Export] private float Spacing = 40f;

    public override void _Ready()
    {
        UpdateQuestUIPosition();
        UpdateQuestText();
    }

    private void UpdateQuestText() { TitleLabel.Text = "Active Quest Title"; }

    private void UpdateQuestUIPosition() { QuestDetailControl.Position = new Vector2(QuestHeaderControl.Position.X, QuestHeaderControl.Position.Y + (QuestHeaderControl.Size.Y * QuestHeaderControl.Scale.Y) + Spacing); }

    private void AddConditionLabels(int totalNumber)
    {
        for (int i = 0; i < totalNumber; i++)
        {
            Label ConditionLabel = new Label();
            AddChild(ConditionLabel);
        }
    }
}
