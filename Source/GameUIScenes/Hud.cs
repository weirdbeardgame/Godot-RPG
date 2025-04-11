using Godot;
using System;
using System.Xml.Resolvers;

public partial class Hud : CanvasLayer
{
    [ExportGroup("UI Scenes Directories")]
    [Export] PackedScene QuestUIScene;

    [ExportGroup("UI Markers")]
    [Export] Control MarkerQuestUI;
    [Export] Godot.Collections.Array<Panel> Previews;

    public override void _Ready()
    {
        HidePreviewPanels();
        
        SetupQuestUI();
    }

    private void SetupQuestUI()
    {
        if (QuestUIScene != null)
        {
            Control questUiInstance = (Control)QuestUIScene.Instantiate();
            MarkerQuestUI.AddChild(questUiInstance); 
        }
    }

    private void HidePreviewPanels()
    {
        foreach(Panel panel in Previews)
        {
            panel.Hide();
        } 
    }
}
