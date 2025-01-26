using Godot;
using System;
using System.Collections.Generic;

public partial class RightClickContext : PopupMenu
{

    public void OpenMenu(InputEvent ev)
    {
        if (ev is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Right)
        {


            Popup();
        }

    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
