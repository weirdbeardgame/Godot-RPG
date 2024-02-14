

public partial class Graph<T> where T : IComparable<T>
{
    private int _NumElements;
    public bool IsDirected;

    // 2d Cordinates, Data
    //private Dictionary<GNode<T>, GNode<T>> _nodes;
    //private Dictionary<(GNode<T>, GNode<T>), Edge<T>> _edges;
    List<Edge<T>> graph;

    public Graph()
    {
        graph = new List<Edge<T>>();
    }

    public void AddEdge(GNode<T> l, GNode<T> r)
    {
        Edge<T> e = new Edge<T>(l, r);
        graph.Add(e);
        _NumElements += 1;
    }
}
