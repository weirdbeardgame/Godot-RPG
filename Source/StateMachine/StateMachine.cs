using Godot;
using System;
using Godot.Collections;

namespace RPG;

public partial class StateMachine : Node
{
    Godot.Collections.Dictionary<string, NodePath> Nodes;

    private State _oldState;
    private State _state;

    public State CurrentState
    {
        get
        {
            return _state;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void AddState(State s, string name)
    {
        if (Nodes == null)
        {
            Nodes = new Godot.Collections.Dictionary<string, NodePath>();
        }
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
                if (_oldState != null)
                {
                    _oldState.Stop();
                }
                _state.Start();
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_state != null)
        {
            _state.FixedUpdate(delta);
        }
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
        if (_state != null)
        {
            _state.Update(delta);
        }
    }
}
