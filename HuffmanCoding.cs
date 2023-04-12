using System.Diagnostics.CodeAnalysis;

namespace assignment_4;

public class HuffmanCoding
{
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
        var left = 2 * index + 1; 
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
    public static Dictionary<char, string> HuffmanTree(string inputText)
    {
        var frequencyDict = CalculateFrequency(inputText);
        var minHeap = MinHeap(frequencyDict);

        // build the Huffman tree
        while (minHeap.Count > 1)
        {
            var leftChild = minHeap[0];
            minHeap.RemoveAt(0);
            var rightChild = minHeap[0];
            minHeap.RemoveAt(0);
            var internalNode = new Node(leftChild.Frequency + rightChild.Frequency, leftChild, rightChild);
            minHeap.Add(internalNode);
            Heapify(minHeap, minHeap.Count - 1);
        }

        var root = minHeap[0];
        var encodingDict = new Dictionary<char, string>();
        Traverse(root, "", encodingDict);
        return encodingDict;
    }

    private static void Traverse(Node node, string code, Dictionary<char, string> encodingDict)
    {
        if (node.Symbol != default(char))
        {
            encodingDict[node.Symbol] = code;
        }
        else
        {
            Traverse(node.LeftChild, code + "0", encodingDict);
            Traverse(node.RightChild, code + "1", encodingDict);
        }
    }

    public static void CodeText(string inputText, string fileName, Dictionary<char, string> decodeDict)
    {
        foreach (var code in decodeDict)
        {
            File.AppendAllText(fileName, $"{code.Key}%{code.Value}#");
        }

        File.AppendAllText(fileName, "@");

        foreach (var letter in inputText)
        {
            var code = decodeDict[letter];
            File.AppendAllText(fileName, code); // there should be a way to write it with bytes
        }
    }
    public static void Decode(string file)
    {
        string encodedText = File.ReadAllText(file);
        var decodeDict = new Dictionary<string, char>();
            
        // Extracting the symbol-code pairs from the encoded text
        string[] pairs = encodedText.Split('@')[0].Split('#', StringSplitOptions.RemoveEmptyEntries);
        foreach (string pair in pairs)
        {
            string[] symbolCode = pair.Split('%');
            decodeDict[symbolCode[1]] = symbolCode[0][0];
        }
        // Decoding the coded text using the decodeDict
        string codedText = encodedText.Substring(encodedText.IndexOf('@') + 1);
        string decodedText = "";
        string currentCode = "";
        foreach (char c in codedText)
        {
            currentCode += c;
            if (decodeDict.ContainsKey(currentCode))
            {
                decodedText += decodeDict[currentCode];
                currentCode = "";
            }
        }
            
        Console.WriteLine(decodedText);
    }
}