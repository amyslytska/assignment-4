namespace assignment4;

public class HuffmanCoding
{
    // 1) Calculate the frequency of each character in the string (dictionary).
    public static Dictionary<char, int> CalculateFrequency(string[] inputText)
    {
        var frequencyDict = new Dictionary<char, int>();
        foreach (var line in inputText)
        {
            foreach(char c in line)
            {
                if(frequencyDict.ContainsKey(c))
                {
                    frequencyDict[c]++;
                }
                else
                {
                    frequencyDict[c] = 1;
                }
            }
        
        }

        return frequencyDict;
    }
    // 2) Sort the characters in increasing order of the frequency using min heap.
    public static List<Node> MinHeap(Dictionary<char, int> frequencyDict)
    {
        var minHeap = frequencyDict.Select(item => new Node(item.Key, item.Value)).ToList();
        
        /* number of nodes/ 2 =>  the index of the last parent node in the minHeap =>
         - 1 (indexing starts from 0, we subtract 1 to get the actual index last parent)
         iterate over all parent nodes until it reaches the root node (index 0)*/        
        for (int i = minHeap.Count / 2 - 1; i >= 0; i--)
        {
            Heapify(minHeap, i);
        }

        return minHeap;
    }
    
    private static void Heapify(List<Node> heap, int index)
    {
        var smallest = index;
        var left = 2 * index + 1; // index of left/right children
        var right = 2 * index + 2;
        
        //check if the l/r child of the current node exists and if it has a smaller frequency than the current

        if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
        {
            smallest = right;
        }
        
        //check if the current node is not the smallest node among its children
        if (smallest != index)
        {
            (heap[index], heap[smallest]) = (heap[smallest], heap[index]); // swap

            Heapify(heap, smallest);
        }
    }

    public Node GetMinimum (List<Node> heap)
    {
        var smallest =  heap[0];
        var i = heap[0].LeftChild.Frequency;
        heap.Remove(smallest);
        Heapify(heap, i);
        return smallest;
    }
    
    // 3) Make each unique character as a leaf node.
    //public static List<Node> HuffmanTree (List<Node> heap, Dictionary<char, int> frequencyDict)
    //{
     //   var tree = List<Node>;
     //   while (!heap.IsEmpty())
     // {
     //   var z = Node(GetMinimum(head).Symbol + GetMinimum(head).RightChild Symbol, heap[0].Frequency + heap[1].Frequency);
     //   tree.Add(z);
     //   return tree;
    //}


    // Create an empty node z. Assign the minimum frequency to the left child of
    // z and assign the second minimum frequency to the right child of z.
    // Set the value of the z as the sum of the above two minimum frequencies.
    
    // 4) Remove these two minimum frequencies from Q and add the sum into the list of frequencies.
    // 5) Insert node z into the tree.
    // 6) Repeat steps 3 to 5 for all the characters.
    // 7) For each non-leaf node, assign 0 to the left edge and 1 to the right edge.

}