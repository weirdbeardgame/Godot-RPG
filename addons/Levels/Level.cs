using Godot;
using System;

namespace Levels
{
    public partial class Level : LevelCommon
    {

        // Take note. SubLevels or scene's can be anything from screens on a 2D tilemap to rooms in a 3D space
        // They're Sub or attached leves or spaces to the currently loaded main one.
        [Export]
        Godot.Collections.Dictionary<string, PackedScene> sublevels;

        [Export]
        public Godot.Collections.Array<Exit> exits;

        LevelCommon ActiveSubScene;

        // Currently active subScene. Otherwise null
        Level subScene;

        Rect2 mapLimits;
        Vector2 mapCellsize;

        public Action Exit;

        public override void EnterLevel()
        {
            base.EnterLevel();
            if (!LoadOrCreateLevelData())
            {
                throw new System.Exception("Level Data failed to Create or Load!");
            }

            Camera = GetNode<Camera2D>("Camera2D");

            Data.LevelState = LevelState.ACTIVE;
            Exit += ExitLevel;

        }

        public bool LoadOrCreateLevelData()
        {
            JsonWrapper json = new JsonWrapper();
            // A non ref-returning property or indexer may not be used as an out or ref value so we create a temp data with the final variable!
            Data = new LevelData();
            var data = new LevelData();

            using var dir = DirAccess.Open("user://");

            if (DirAccess.Open("user://Save/LevelData") == null)
            {
                dir.MakeDirRecursive("user://Save/LevelData");
            }

            if (!FileAccess.FileExists($"user://Save/LevelData/{LevelName}.json"))
            {
                Data = new LevelData();
                return json.Write($"user://Save/LevelData/{LevelName}.json", Data);
            }

            else if (json.Read($"user://Save/LevelData/{LevelName}.json", ref data))
            {
                Data = data;
                return true;
            }
            return false;
        }


        public override void Update()
        {
            base.Update();
        }

        public override void ResetLevel()
        {
            ExitLevel();
            EnterLevel();
        }

        // Clear the enemies and other data from the scene.
        // Ensure the scene closes properly before changing.
        public override void ExitLevel()
        {
            RemoveChild(Player);
        }
    }
}