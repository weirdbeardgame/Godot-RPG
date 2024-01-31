using Godot;
using System;

public enum Job { MAGE, WARRIOR, FIGHTER, DRAGOON, THIEF, SAMURAI };

public partial class JobSystem : Node
{
    Job _CurrentJob;
    public Job CurrentJob => _CurrentJob;

    // Note, this function should only ever be called once!
    // To switch a characters job use Change Job!
    public void SetJob(Job j) => _CurrentJob = j;

    // TO DO: implement a change to stats when Job changes!
    // Warrior to Mage for instance would lower attack but potentially raise magic.
    // You can also calculate based on current level if it would be more damaging to stats
    // Or, if they've previously held the job before.
    public void ChangeJob(Job j)
    {
        if (_CurrentJob != j)
        {
            _CurrentJob = j;
        }
    }

}
