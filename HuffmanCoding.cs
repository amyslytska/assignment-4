namespace assignment4;

public class HuffmanCoding
{
    // 1) Calculate the frequency of each character in the string (dictionary).
    public static Dictionary<char, int> CalculateFrequency(string[] inputText)
    {
        var frequencyDict = new Dictionary<char, int>();
        foreach (string line in inputText)
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
    // 2) Sort the characters in increasing order of the frequency. Using priority queue
    // or MIN HEAP.
    
    // 3) Make each unique character as a leaf node.
    // Create an empty node z. Assign the minimum frequency to the left child of
    // z and assign the second minimum frequency to the right child of z.
    // Set the value of the z as the sum of the above two minimum frequencies.
    
    // 4) Remove these two minimum frequencies from Q and add the sum into the list of frequencies.
    // 5) Insert node z into the tree.
    // 6) Repeat steps 3 to 5 for all the characters.
    // 7) For each non-leaf node, assign 0 to the left edge and 1 to the right edge.

}