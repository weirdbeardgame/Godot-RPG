using Godot;
using System;

[Tool]
public partial class PlayerEditor : Panel
{
    private Button _newPlayer;
    private PlayerData _currentPlayer;
    private Button _save;

    public override void _EnterTree()
    {
        base._EnterTree();
        _newPlayer = GetNode<Button>("HBoxContainer/NewPlayer");

    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }

}
