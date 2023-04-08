namespace assignment_4;

public class Node : IComparable<Node>
{
    public char Symbol { get; set; }
    public int Frequency { get; set; }
    public Node LeftChild { get; set; }
    public Node RightChild { get; set; }
    
    public Node(char symbol, int frequency)
    {
        Symbol = symbol;
        Frequency = frequency;
    }
    
    // LeafNode constructor
    public Node(int frequency, Node leftChild, Node rightChild)
    {
        Frequency = frequency;
        LeftChild = leftChild;
        RightChild = rightChild;
    }
    
    public int CompareTo(Node other)
    {
        return Frequency.CompareTo(other.Frequency);
    }
    
    public List<int> Search(char symbol, List<int> path)
    {
        // Leaf
        if (RightChild == null && LeftChild == null)
        {
            if (symbol == this.Symbol)
            {
                return path;
            }
            else
            {
                return null;
            }
        }
        else
        {
            List<int> pathLeft = null;
            List<int> pathRight = null;

            if (LeftChild != null)
            {
                var leftPath = new List<int>();
                leftPath.AddRange(path);
                leftPath.Add(0);

                pathLeft = LeftChild.Search(symbol, leftPath);
            }

            if (RightChild != null)
            {
                var rightPath = new List<int>();
                rightPath.AddRange(path);
                rightPath.Add(1);
                pathRight = RightChild.Search(symbol, rightPath);
            }

            if (pathLeft != null)
            {
                return pathLeft;
            }
            else
            {
                return pathRight;
            }
        }
    }
}