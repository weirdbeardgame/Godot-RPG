using Godot;
using System;

public partial class Npc : Node2D
{
    int id;
    string NpcName;
    Sprite2D NpcSprite;
    Graph<DialogueNode> Conversation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
