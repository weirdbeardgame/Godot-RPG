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

    public int CompareTo(DialogueNode obj) => 
        _id < obj._id ? -1 : 
        _id > obj._id ?  1 : 0;
}
