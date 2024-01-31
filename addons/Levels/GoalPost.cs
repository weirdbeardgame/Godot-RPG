using Godot;
using System;

namespace RPG;

public partial class GoalPost : Area2D
{
    // To Do add gui selector in here for hub to transition to from SceneManager
    [Export] string hub;
    LevelCommon current;

    public override void _Ready()
    {
        current = (LevelCommon)GetParent();
    }

    public void OnTouch(Node body)
    {
        if (body is Player)
        {
            current.CompleteLevel();
            SceneManager.ChangeScene(hub, (Player)body);
        }
    }
}
