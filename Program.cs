namespace assignment_4;

internal class Program
{
    public static void Main(string[] args)
    {
        var inputText = File.ReadAllText("C:/Users/KHRYSTYNA/RiderProjects/assignment-4/test_6s.txt");
        inputText = inputText.Replace("\r\n", "\n");
        var frequency = HuffmanCoding.CalculateFrequency(inputText);

        var minHeap = HuffmanCoding.MinHeap(frequency);
        
        // coding by our dict
        var name = "C:/Users/KHRYSTYNA/RiderProjects/assignment-4/coded_text.txt";
        // var codedText = File.Create(name);
        HuffmanCoding.CodeText(inputText, name, HuffmanCoding.HuffmanTreeDecode(minHeap));
        
        var decodingFile = File.ReadAllText(name);
        HuffmanCoding.Decode(decodingFile);

    }
}


