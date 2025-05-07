using Godot;


// a WIP concept
public partial class Turn : Node
{
    public Creature TurnTaker;
    private bool _isActive;

    public void SetIsActive(bool isActive) => _isActive = isActive;

    public void Execute()
    {
        if (_isActive)
        {
            // Execute actions in here.
        }
    }

}