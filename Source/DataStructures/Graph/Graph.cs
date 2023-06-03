
namespace RPG;
public partial class Graph<T> where T : IComparable<T>
{
    private int _numElements;
    public bool IsDirected;

    // 2d Cordinates, Data
    private Dictionary<GNode<T>, GNode<T>> _nodes;
    private Dictionary<(GNode<T>, GNode<T>), Edge<T>> _edges;

    public void AddNode(int row, int col, GNode<T> dat)
    {
        //matrix[(row, col)] = dat;
    }

}
