using Godot;


// a WIP concept
public partial class Turn : Node
{
    public Creature TurnTaker;
    private bool _isActive;
    public iAction QueuedAction;

    public void SetIsActive(bool isActive) => _isActive = isActive;

    public void Execute()
    {
        if (_isActive)
        {
            QueuedAction.Execute();
        }
    }

}