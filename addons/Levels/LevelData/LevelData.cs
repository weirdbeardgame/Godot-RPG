using Godot;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Levels
{
    public partial class LevelData : ILevelData
    {
        public bool Unlocked { get; set; }
        public LevelState LevelState { get; set; }
        public int MaximumAmountOfEnimies { get; set; }

        // List<Enemy> EnemiesToSpawn;

        public LevelData()
        {
            Unlocked = true;
            LevelState = LevelState.NON_COMPLETE;
            MaximumAmountOfEnimies = 0;
        }

    }
}