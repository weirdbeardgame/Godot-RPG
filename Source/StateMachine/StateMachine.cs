
public partial class StateMachine : Node
{
    private Godot.Collections.Dictionary<string, NodePath> _nodes;
    private State _oldState;
    private State _state;
    public State CurrentState => _state;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void AddState(State s, string name)
    {
        _nodes ??= new Godot.Collections.Dictionary<string, NodePath>();

        if (!_nodes.ContainsKey(name) && _nodes != null)
        {
            _nodes.Add(name, s.GetPath());
        }
        else
        {
            return;
        }
    }

    public void InitDefaultState(string stateName)
    {
        _state = (State)GetNode(_nodes[stateName]);
        _state.Start();
    }

    public void UpdateState(string newState)
    {
        if (_state != null)
        {
            if (_state.StateName != newState)
            {
                _oldState = _state;
                _state = (State)GetNode(_nodes[newState]);
                _oldState?.Stop();
                _state.Start();
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        // Seems inefficent to check if state is null every frame
        _state?.FixedUpdate(delta);
    }

    // Take the current _state and restart it's logic, IE. You're going to double jump!
    public void ResetState()
    {
        var stateTemp = GetNode<State>(_nodes[CurrentState.StateName]);
        _state.Stop();
        _state = null;
        _state = stateTemp;
        _state.Start();
    }

    public void ResetToOldState()
    {
        _state = null;
        _state = _oldState;
        _state.Start();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Seems inefficent to check if state is null every frame
        // Why are you doing _state?.Update(delta) in both _Process and _PhysicsProcess?
        // Did you mean to just do one?
        _state?.Update(delta);
    }
}
