using Godot;
using System;

namespace RPG;

[Tool]
public partial class DNode : GraphNode
{
    DialogueNode _dialogueN;
    bool _isClicked;

    public DialogueNode DialogueNode
    {
        get
        {
            return _dialogueN;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _dialogueN = new DialogueNode();
    }

    public void ChangedSpeaker(string e)
    {
        GD.Print("ChangedSpeaker");
        _dialogueN.SpeakerName = e;
    }

    public void ChangedDialogue(string e)
    {
        GD.Print("ChangedDialogue");
        _dialogueN.Dialogue = e;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (_isClicked)
        {
            GD.Print("CLICKED");
            GlobalPosition = GetViewport().GetMousePosition();
        }
    }
}
