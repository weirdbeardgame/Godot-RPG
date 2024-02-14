

// Node type for graphs, any needed logic can go in here
public partial class GNode<T> : NodeCommon<T>
{
    public GNode()
    {
        NodeID = 0;
    }

    public GNode(T Dat)
    {
        Data = Dat;
    }

}