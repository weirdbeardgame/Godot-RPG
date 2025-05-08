using Godot;

// For turn based games
public partial class Turn : Node
{
    public Creature TurnTaker;
    private bool _isActive;
    public iAction QueuedAction;
    public static Action<Creature> TurnActive;
    public void SetIsActive(bool isActive) => _isActive = isActive;

    public void QueueUpAction(iAction action)
    {
        if (QueuedAction != action)
        {
            QueuedAction = action;
        }
    }

    public void Execute()
    {
        if (_isActive)
        {
            QueuedAction.Execute();
        }
    }

}