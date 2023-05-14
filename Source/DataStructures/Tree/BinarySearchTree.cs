using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RPG;

[System.Serializable]
public class BinarySearchTree<T> where T : IComparable<T>
{
    private int _numElements;
    public TNode<T> Tree;

    private List<T> _temp;

    private bool _placeFound;

    public int Size
    {
        get
        {
            return _numElements;
        }
    }

    public BinarySearchTree()
    {
        _numElements = 0;
        Tree = null;
    }

    // This may only go one level deep at present!
    // Also, use of "NodeID" will mean this is only a right leaning Tree
    public void Insert(T data) // Push to tree
    {
        TNode<T> _tempTree;
        TNode<T> _treeData = new TNode<T>(data);
        bool IsInserted = false;

        while (!IsInserted)
        {
            _tempTree = Tree;

            if (_tempTree == null)
            {
                _tempTree = _treeData;
                _tempTree.IsRoot = true;
                _numElements += 1;
                IsInserted = true;
                return;
            }

            if (_treeData < _tempTree)
            {
                _tempTree = _tempTree.AddLeft(_tempTree, data);
                _numElements += 1;
                IsInserted = true;
                return;
            }
            else if (_treeData > _tempTree)
            {
                _tempTree = _tempTree.AddRight(_tempTree, data);
                _numElements += 1;
                IsInserted = true;
                return;
            }
        }
    }

    public void TraversePostfix(TNode<T> node)
    {
        if (node != null)
        {
            TraversePostfix(node.Left);
            TraversePostfix(node.Right);
            Console.Write(node.Data + " ");
        }
    }

    void TraversePrefix(TNode<T> node)
    {
        if (node != null)
        {
            Console.Write("data: " + node.Data);
            TraversePrefix(node.Left);
            TraversePrefix(node.Right);
        }
    }

    public List<T> Getdata()
    {
        _temp = new List<T>();

        TNode<T> _tempTree = Tree;

        if (_tempTree != null)
        {
            Save(_tempTree);
        }
        return _temp;
    }

    public TNode<T> Save(TNode<T> node)
    {

        if (!_temp.Contains(node.Data))
        {
            _temp.Add(node.Data);
        }

        if (node.Right != null)
        {
            if (!_temp.Contains(node.Right.Data))
            {
                _temp.Add(node.Right.Data);
            }
            return Save(node.Right);
        }

        if (node.Left != null)
        {
            if (!_temp.Contains(node.Left.Data))
            {
                _temp.Add(node.Left.Data);
            }
            return Save(node.Left);
        }

        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return enumerate(Tree).GetEnumerator();
    }

    IEnumerable<T> enumerate(TNode<T> root)
    {
        if (root == null)
            yield break;

        yield return root.Data;

        foreach (var value in enumerate(root.Left))
            yield return value;

        foreach (var value in enumerate(root.Right))
            yield return value;
    }

    public static BinarySearchTree<T> operator ++(BinarySearchTree<T> tree)
    {
        BinarySearchTree<T> _tempTree;

        if (tree == null)
        {
            return null;
        }

        else
        {
            _tempTree = tree;

            if (_tempTree.Tree.Right != null)
            {

                _tempTree.Tree.Right.Parent = _tempTree.Tree;

                _tempTree.Tree = _tempTree.Tree.Right;

                if (_tempTree.Tree.Right == null)
                {
                    return null;
                }

                if (_tempTree.Tree.Left != null)
                {
                    while (_tempTree.Tree.Left != null)
                    {
                        _tempTree.Tree = _tempTree.Tree.Left;
                    }
                }

            }
        }
        return _tempTree;
    }

    void GrabTree(List<TNode<T>> Balance, TNode<T> node)
    {
        if (Balance == null)
        {
            Balance = new List<TNode<T>>();
        }

        if (node == null)
        {
            return;
        }

        GrabTree(Balance, node.Left);
        Balance.Add(node);
        GrabTree(Balance, node.Right);

    }

    public virtual TNode<T> BuildTreeUtil(List<TNode<T>> Nodes, int start, int end)
    {
        // base case
        if (start > end)
        {
            return null;
        }

        /* Get the middle element and make it root */
        int mid = (start + end) / 2;
        TNode<T> node = Nodes[mid];

        /* Using index in dataInorder traversal, construct
           left and right subtress */
        node.Left = BuildTreeUtil(Nodes, start, mid - 1);
        node.Right = BuildTreeUtil(Nodes, mid + 1, end);

        return node;
    }

    // This functions converts an unbalanced BST to a balanced BST
    public virtual TNode<T> BalanceTree(TNode<T> root)
    {
        // Store nodes of given BST in sorted order
        List<TNode<T>> nodes = new List<TNode<T>>();
        GrabTree(nodes, root);

        // Constucts BST from nodes[]
        int n = nodes.Count;
        return BuildTreeUtil(nodes, 0, n - 1);
    }

    public void TraverseInOrder(TNode<T> node)
    {
        if (node == null)
        {
            return;
        }

        TraverseInOrder(node.Left);
        Console.Out.WriteLine("data: " + node.Data.ToString());
        TraverseInOrder(node.Right);
    }

    public TNode<T> Find(T data, TNode<T> node)
    {
        if (node != null)
        {
            if (node.Data.CompareTo(data) > 0)
            {
                return Find(data, node.Right);
            }

            if (node.Data.CompareTo(data) == 0)
            {
                return Find(data, node.Left);
            }

            else
            {
                return node;
            }
        }

        return null;
    }

    TNode<T> Pull(T data, TNode<T> node) // Pull next item from tree
    {
        TNode<T> Tdata = Find(data, node);
        TNode<T> dataToReturn = Tdata;

        Remove(data, Tdata);
        return dataToReturn;
    }

    T minValue(TNode<T> root)
    {
        T minv = root.Data;
        while (root.Left != null)
        {
            minv = root.Left.Data;
            root = root.Left;
        }
        return minv;
    }


    public TNode<T> Remove(T data, TNode<T> node) // Removes one item
    {

        TNode<T> ToDelete = Find(data, node);
        ToDelete = null;

        if (node == null)
        {
            return null;
        }


        if (data.CompareTo(node.Data) == 0)
        {
            node.Left = Remove(data, node.Left);
        }

        else if (data.CompareTo(node.Data) > 0)
        {
            node.Right = Remove(data, node.Right);
        }

        else // we deletin root
        {

            if (node.Left == null)
            {
                return node.Right;
            }

            else if (node.Right == null)
            {
                return node.Left;
            }

            node.Data = minValue(node.Right);

            node.Right = Remove(node.Data, node.Right);

            node = null;
        }

        return node;
    }


    void DeleteBinaryTree(TNode<T> deletor)
    {

        if (deletor == null)
        {
            return;
        }

        DeleteBinaryTree(deletor.Left);
        DeleteBinaryTree(deletor.Right);

        deletor = null;
    }

    public void Clear() // Clears the entire tree.
    {
        DeleteBinaryTree(Tree);
        _numElements = 0;
        Tree = null;
    }

    ~BinarySearchTree()
    {

    }
}


public class TreeSerialize<T> : JsonConverter
{

    private readonly Type[] _types;

    List<T> _temp;

    List<List<T>> _tempTreeTrees;

    public TreeSerialize(params Type[] types)
    {
        _types = types;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {

        TNode<T> Tree = value as TNode<T>;

        TNode<T> _tempTree = Tree;

        List<TNode<T>> TreeList = new List<TNode<T>>();

        writer.WriteStartArray();

        serializer.Serialize(writer, Tree.Data);

        if (_tempTree.Parent != null)
        {
            TreeList.Add(_tempTree.Parent);
            //serializer.Serialize(writer, _tempTree.Parent);
        }

        if (_tempTree.Left != null)
        {
            TreeList.Add(_tempTree.Left);
            _tempTree = _tempTree.Left;
            //serializer.Serialize(writer, _tempTree.Left);
            //WriteJson(writer, _tempTree.Left, serializer);

        }

        if (_tempTree.Right != null)
        {
            TreeList.Add(_tempTree.Right);
            _tempTree = _tempTree.Right;
            //serializer.Serialize(writer, _tempTree.Right);
            //WriteJson(writer, _tempTree.Right, serializer);
        }


        JsonConvert.SerializeObject(TreeList);

    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonToken.StartArray)
        {

            JToken token = JToken.Load(reader);

            _tempTreeTrees = token.ToObject<List<List<T>>>();

            //_tempTree = new List<T>();

            //_tempTree.Add((T)existingValue);

            /*if (!_tempTreeTrees.Contains(_tempTree))
            {
                _tempTreeTrees.Add(_tempTree);
            }*/

        }
        return _tempTreeTrees;

    }

    public override bool CanRead
    {
        get { return false; }
    }

    public override bool CanConvert(Type objectType)
    {
        return _types.Any(t => t == objectType);
    }
}