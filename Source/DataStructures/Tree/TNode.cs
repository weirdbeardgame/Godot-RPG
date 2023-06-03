namespace RPG;

// Should make a common node type since this matches Tree logic. Graphs don't follow that persay
// IComparable comes from NodeCommon, but Node Types can differ per structure. This will worry about tree root and position
// Graphs will worry about direction and edges 
[Serializable]
public class TNode<T> : NodeCommon<T>
{
    public TNode<T> Parent;
    public TNode<T> Left;
    public TNode<T> Right;

    public bool IsRoot;

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

    ~TNode()
    {

    }
}
