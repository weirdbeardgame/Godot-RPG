using Godot;
using RPG;
using System;

public enum EventTypes { CUTSCENE, GIVE, TAKE, DIALOG, PLAY_SOUND, FOLLOW_PLAYER }

public partial class Event : Node
{
    protected string EventName;
    protected EventTypes EventType;

    public virtual void Play(Player p)
    {
    }

    public virtual void Stop()
    {
    }
}
