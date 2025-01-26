
namespace Levels
{
    public enum LevelState { COMPLETE, ACTIVE, NON_COMPLETE }

    public interface ILevelData
    {
        public bool Unlocked { get; set; }
        public LevelState LevelState { get; set; }
    }
}