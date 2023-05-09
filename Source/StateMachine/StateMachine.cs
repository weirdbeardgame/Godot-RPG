namespace RPG;

// Since this is defined after the namespace, it will always override the
// global usings. So for example if you had global using System.Collections.Generic
// This local using would override that. If it was defined before the line of the
// namespace, this would not be the case.
using Godot.Collections;

public partial class StateMachine : Node
{
    Dictionary<string, NodePath> Nodes;

    private State _oldState;
    private State _state;

    public State CurrentState => _state;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
    }

    public void AddState(State s, string name)
    {
        Nodes ??= new Dictionary<string, NodePath>();

        if (!Nodes.ContainsKey(name) && Nodes != null)
        {
            Nodes.Add(name, s.GetPath());
        }
        else
        {
            return;
        }
    }

    public void InitState(string defaultState)
    {
        _state = (State)GetNode(Nodes[defaultState]);
        _state.Start();
    }

    public void UpdateState(string newState)
    {
        if (_state != null)
        {
            if (_state.StateName != newState)
            {
                _oldState = _state;
                _state = (State)GetNode(Nodes[newState]);
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
        var stateTemp = GetNode<State>(Nodes[CurrentState.StateName]);
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
