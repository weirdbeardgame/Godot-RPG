

public partial class Edge<T>
{
    GNode<T> _left;
    GNode<T> _right;
    T dat;

    public Edge(GNode<T> l, GNode<T> r)
    {
        _left = l;
        _right = r;
    }

}