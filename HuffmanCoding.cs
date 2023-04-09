namespace assignment_4;

public class HuffmanCoding
{
    // 1) Calculate the frequency of each character in the string (dictionary).
    public static Dictionary<char, int> CalculateFrequency(string inputText)
    {
        var frequencyDict = new Dictionary<char, int>();
        foreach (var c in inputText)
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

    public static Node GetMinimum (List<Node> heap)
    {
        var smallest =  heap[0];
        heap.Remove(smallest);
        Heapify(heap, heap.Count);
        return smallest;
    }
    
   public static List<Node> HuffmanTree(List<Node> heap)
    {
        var tree = new List<Node>(heap);
        while (tree.Count > 1)
        {
            var min1 = GetMinimum(tree);
            var min2 = GetMinimum(tree);
            // created leafnodes
            var z = new Node( min1.Frequency + min2.Frequency, min1, min2);
            tree.Add(z);
            Heapify(tree, tree.Count);
        }
        return tree;
    }
    // 

    public static Dictionary<char, int> HuffmanTreeDecode(List<Node> heap)
    {
        var codingDict = new Dictionary<char, int>();
        var root = HuffmanTree(heap)[0];
        foreach (var node in heap)
        {
            var symbol = node.Symbol;
            var code = int.Parse(string.Join("", root.Search(symbol, new List<int>())));
            codingDict[symbol] = code;
        }
        return codingDict;
    }


    public static void CodeText(string inputText, string fileName, Dictionary<char, int> decodeDict)
    {
        foreach (var code in decodeDict)
        {
            File.AppendAllText(fileName, $"{code.Key}:{code.Value}#");
        }

        File.AppendAllText(fileName, "@");

        foreach (var letter in inputText)
        {
            var code = decodeDict[letter].ToString();
            File.AppendAllText(fileName, code); // there should be a way to write it with bytes
        }
    }


    public static void Decode(string codedText)
    {
        var decodedText = "";
        var pressedDict = codedText.Split("@")[0].Split("#");
        var codingDict = new Dictionary<char, int>();
        var codedString = codedText.Split("@")[1];
        
        foreach (var item in pressedDict)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var keyValue = item.Split(":");
                codingDict[keyValue[0][0]] = int.Parse(keyValue[1]);
            }
        }
        
        var currentCode = "";
        foreach (var digit in codedString)
        {
            currentCode += digit;
            if (codingDict.ContainsValue(int.Parse(currentCode)))
            {
                decodedText += codingDict.FirstOrDefault(x => x.Value == int.Parse(currentCode)).Key;
                currentCode = "";
            }
        }

        Console.Write(decodedText);
    }
}