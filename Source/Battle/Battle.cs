using Godot;

public partial class Battle : Node
{
    public Party PlayerParty;
    public Party EnemyParty;

    public Queue<iAction> quededActions;

    public void Init()
    {

    }

    public void Start()
    {

    }


    public void BattleLoop()
    {
        if (CheckEndCondition())
        {
            // Do it! And I'll break the loop, Dr. Strange
        }
    }

    bool CheckEndCondition()
    {
        if (EnemyParty.IsDead)
        {
            GD.Print("Enemies ded");
            return true;
        }

        if (PlayerParty.IsDead)
        {
            GD.Print("Players ded");
            return true;
        }

        return false;
    }

}