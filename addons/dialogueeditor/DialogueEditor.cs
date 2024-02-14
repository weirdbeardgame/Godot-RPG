#if TOOLS
using Godot;
using System;



[Tool]
public partial class DialogueEditor : EditorPlugin
{
    PackedScene DEditor = ResourceLoader.Load<PackedScene>("res://addons/dialogueeditor/DialogueEditor.tscn");
    Control DEditorInstance;

    public override void _EnterTree()
    {
        DEditorInstance = (Control)DEditor.Instantiate();

        // Add the main panel to the editor's main viewport.
        GetEditorInterface().GetEditorMainScreen().AddChild(DEditorInstance);

        // Hide the main panel. Very much required.
        _MakeVisible(false);
    }

    public override void _ExitTree()
    {
        if (DEditorInstance != null)
        {
            DEditorInstance.QueueFree();
        }
    }

    public override bool _HasMainScreen()
    {
        return true;
    }

    public override void _MakeVisible(bool visible)
    {
        if (DEditorInstance != null)
        {
            DEditorInstance.Visible = visible;
        }
    }

    public override string _GetPluginName()
    {
        return "Dialogue Editor";
    }

    public override Texture2D _GetPluginIcon()
    {
        return GetEditorInterface().GetBaseControl().GetThemeIcon("Node", "EditorIcons");
    }
}
#endif
