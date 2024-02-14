

public partial class Pause : State
{
    private SceneTree _tree;

    // Ready happens before start
    public override void _Ready()
    {
        _tree = GetTree();

        StateName = "Pause";
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.AddState(this, StateName);
    }

    public override void Start() => _tree.Paused = true;
    public override void Stop() => _tree.Paused = false;
}