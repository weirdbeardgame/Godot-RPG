using Godot;
using System;
using System.Diagnostics;

namespace Core.UI;

public partial class Hud : CanvasLayer
{
    private bool hudInitialized = false;
    // The idea is that we provide the implementation of the Hud System and let devs either choose one
    // of our premade UI scenes or pop in and out their own handcrafted UI Scenes right from the editor

    [ExportGroup("UI Scenes Directories")]
    [Export] PackedScene PlayerStatUIScene;
    [Export] PackedScene PartyStatUIScene;
    [Export] PackedScene MiniMapUIScene;
    [Export] PackedScene QuestUIScene;

    // These Control Nodes are made to determine the size and position of their respective UI scene both
    // at ready as well as runtime
    
    [ExportGroup("UI Markers")]
    [Export] Control MarkerPlayerStatUI;
    [Export] Control MarkerPartyStatUI;
    [Export] Control MarkerMiniMapUI;
    [Export] Control MarkerQuestUI;
    [Export] Godot.Collections.Array<Control> Previews; // Just for showcasing the child UI's size and position

    public override void _Ready()
    {
        if (hudInitialized) { return; }

        HidePreviewPanels();
        InitializeHud();
    }

    private void InitializeHud()
    {
        SetupPlayerStatUI();
        SetupPartyStatUI();
        SetupMiniMapUI();
        SetupQuestUI();
    }

    private void SetupPlayerStatUI() 
    { 
        if (PlayerStatUIScene != null)
        {
            Control playerUiInstance = (Control)PlayerStatUIScene.Instantiate();
            MarkerPlayerStatUI.AddChild(playerUiInstance);
            // playerUiInstance.UpdateUI();
        } 
    }
    private void SetupPartyStatUI() { Debug.Print("Showing Party Stats"); }
    private void SetupMiniMapUI() { Debug.Print("Showing MiniMap"); }
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
            panel.QueueFree();
        } 
    }
}
