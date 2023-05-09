// You have this under a folder called Common so im not sure if you want RPG namespace
// here. Either way it's good practice to use namespaces. Maybe something like
// namespace Common;
namespace RPG;

[Serializable]
public class TNode<T> : IComparable<TNode<T>>
{
    public T Data;

    public TNode<T> Parent;
    public TNode<T> Left;
    public TNode<T> Right;

    public bool IsRoot;

    public int NodeID;

    public TNode(T Dat)
    {
        Data = Dat;
    }

    public TNode<T> AddLeft(TNode<T> PNode, T Data)
    {
        var ItemNode = new TNode<T>(Data);

        if (PNode.Left == null)
        {
            ItemNode.NodeID++;

            PNode.Left = ItemNode;

            ItemNode.Parent = PNode; // To establish the Root of the new node or rather the "Previous"

            return PNode;
        }

        else if (PNode.Left != null)
            return AddLeft(PNode.Left, Data);

        return null;
    }

    public void AddLeft(TNode<T> Node, TNode<T> Child) // If I feel it nessacary to add a copy function. This would be used
    {
        if (Child == null)
            return;

        //The referenced one points forward to the new one.
        Node.Left = Child;

        //The new one needs to point to the passed one
        Child.Parent = Node; //The new one points backward to the referenced one

    }

    public TNode<T> AddRight(TNode<T> PNode, T Dat)
    {
        var ItemNode = new TNode<T>(Dat);

        if (PNode.Right == null)
        {
            ItemNode.NodeID += 1;

            PNode.Right = ItemNode;

            ItemNode.Parent = PNode; // To establish the Root of the new node or rather the "Previous"

            return PNode;
        }

        else if (PNode.Right != null)
            return AddRight(PNode.Right, Data);

        return null;
    }

    public void AddRight(TNode<T> Node, TNode<T> Child)
    {
        if (Child == null)
            return;

        //The referenced one points forward to the new one.
        Node.Right = Child;

        //The new one needs to point to the passed one
        Child.Parent = Node; //The new one points backward to the referenced one
    }

    int Size()
    {
        return 0;
    }

    public static bool operator >(TNode<T> T1, TNode<T> T2) => T1.CompareTo(T2) > 0;
    public static bool operator <(TNode<T> T1, TNode<T> T2) => T1.CompareTo(T2) == 0;

    public int CompareTo(TNode<T> obj) =>
        NodeID < obj.NodeID ? -1 :
        NodeID > obj.NodeID ?  1 : 0;

    ~TNode()
    {

    }
}
