

public partial class State : Node
{
    protected StateMachine StateMachine;

    public string StateName;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public virtual void Start()
    {

    }

    public virtual void Stop()
    {
    }

    public virtual Vector3 GetInput()
    {
        return Vector3.Zero;
    }

    public virtual void Update(double delta)
    {
    }

    public virtual void FixedUpdate(double delta)
    {

    }
}
