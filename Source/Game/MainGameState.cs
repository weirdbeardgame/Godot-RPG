

// Here be where normal game logic is processed
public partial class MainGameState : State
{
    // Ready happens before start
    public override void _Ready()
    {
        StateName = "MainGameState";
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.AddState(this, StateName);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update(double delta)
    {

    }

    public override void Stop()
    {
        base.Stop();
    }
}
