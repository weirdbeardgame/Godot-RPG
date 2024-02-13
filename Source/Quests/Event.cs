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

public partial class GiveItemEvent : Event
{
    [Export]
    Item ToGive;

    public override void Play(Player p) => p.RecieveItem(ToGive);
}
