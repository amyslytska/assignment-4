namespace assignment_4;

internal class Program
{
    public static void Main(string[] args)
    {
        var inputText = File.ReadAllText("C:/Users/annmy/RiderProjects/assignment-4/sherlock.txt");
        inputText = inputText.Replace("\r\n", "\n");
        var name = "C:/Users/annmy/RiderProjects/assignment-4/coded_text.txt";
        
        HuffmanCoding.CodeText(inputText, name, HuffmanCoding.HuffmanTree(inputText));
        
        HuffmanCoding.Decode(name);

    }
}


