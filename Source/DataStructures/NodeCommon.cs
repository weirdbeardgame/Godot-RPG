namespace RPG;


public class NodeCommon<T> : IComparable<NodeCommon<T>>
{
    public T Data;
    int NodeID;


    public static bool operator >(NodeCommon<T> T1, NodeCommon<T> T2) => T1.CompareTo(T2) > 0;
    public static bool operator <(NodeCommon<T> T1, NodeCommon<T> T2) => T1.CompareTo(T2) == 0;

    public int CompareTo(NodeCommon<T> obj) =>
        NodeID < obj.NodeID ? -1 :
        NodeID > obj.NodeID ? 1 : 0;

}