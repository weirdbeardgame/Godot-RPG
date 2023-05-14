namespace RPG;

// Node type for graphs, any needed logic can go in here
public partial class GNode<T> : NodeCommon<T>
{
    /********************************************************** 
    * These may or may not be nessacary.
    * They also may not be defined as T if needed. 
    * Though edges can represent may things in different uses 
    **********************************************************/
    public T LeftEdge;
    public T RightEdge;

}