using Godot;
using System;
using System.IO;
using System.Collections.Generic;

namespace RPG;

public enum NodeType { DIALOUGE, FLAG, CHOICE, EVENT }
public enum NodeDirection { LEFT, RIGHT }

// Can be as simple as "Yes, No" or full ass elder scrolls shit
public struct ChoiceData
{
    public string ChoiceName;
    public NodeDirection Dir;
};

public partial class DialogueNode : IComparable<DialogueNode>
{
    int _id;
    public string SpeakerName;
    public string Dialogue;

    public List<ChoiceData> Choices;

    public NodeType Type;

    public int CompareTo(DialogueNode obj)
    {
        if (_id < obj._id)
        {
            return -1;
        }

        if (_id > obj._id)
        {
            return 1;
        }

        return 0;
    }
}
