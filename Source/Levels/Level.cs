using Godot;
using Levels;
using System;

[Tool]
public partial class Level : LevelCommon
{
    // For classic 2D - 3D non action battle era Jrpg's that utilzed random battle step counter system
    public bool CanBattle; // Will the step counter or anything like that be active here?

    private LevelData _levelData;

    // The player body that exists in the level that you interact with.
    private Player _playerEntityInLevel;

    public Level()
    {

    }

    public Level(string name)
    {
        // Name of node in tree and Name of Level
        Name = name;
        LevelName = name;
        Data = new LevelDataCommon();
    }

    public override void EnterLevel()
    {
        base.EnterLevel();

        AddChild(_playerEntityInLevel);
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void FixedUpdate(double delta)
    {
        base.FixedUpdate(delta);
    }

    // Steps to take:
    // A. Check if CanBattle
    // B. Select random Enemy entity from EnemySpawns
    // C. Pass Player and Enemy data to Battle System
    // D. Select Battle Stage based on current level. Is this the grass, water, dungeon or other stage?
    public void InitateBattle()
    {
        if (CanBattle)
        {
            var rand = new Random();
            int idx = rand.Next(0, _levelData.EnemySpawns.Count);

            var selectedEne = _levelData.GetEnemy(idx);

            // Pass Ene and Player data to battle system here
        }
    }

    public override void ExitLevel()
    {
        base.ExitLevel();
    }

}
