using Levels;


public partial class LevelData : LevelDataCommon
{
    private List<Enemy> _enemySpawns;
    public List<Enemy> EnemySpawns => _enemySpawns;

    //private List<QuestTrigger> _triggers; // This would be for Ye Olde 2d RPG's with a loctional quest trigger tile

    public override void Create()
    {
        base.Create();

        // To Do, add logic to grab _enemySpawns and initalize map logic
    }

    public Enemy GetEnemy(int idx)
    {
        if (idx <= _enemySpawns.Count)
        {
            return _enemySpawns[idx];
        }

        return null;
    }


}