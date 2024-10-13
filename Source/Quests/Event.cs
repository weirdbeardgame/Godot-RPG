using Godot;
using System;

namespace Core.Quests;

public enum EventTypes { CUTSCENE, GIVE, TAKE, DIALOG, PLAY_SOUND, FOLLOW_PLAYER }

public partial class Event : Node
{
    protected string _eventName;
    protected EventTypes _eventType;

    public virtual void Play(Player p)
    {
    }

    public virtual void Stop()
    {
    }
}
