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
}