namespace assignment4;
using System;

internal class Program
{
    public static void Main(string[] args)
    {
        var inputText = File.ReadAllLines("C:/Users/KHRYSTYNA/RiderProjects/assignment-4/sherlock.txt");
        var frequency = HuffmanCoding.CalculateFrequency(inputText);
        /*Console.Write("Enter a symbol: ");
        char symbol = Console.ReadLine()[0];
        if (frequency.ContainsKey(symbol))
        {
            Console.WriteLine("The frequency of '{0}' is {1}", symbol, frequency[symbol]);
        }
        else
        {
            Console.WriteLine("'{0}' is not found", symbol);
        }*/

        var minHeap = HuffmanCoding.MinHeap(frequency);

        foreach (var node in minHeap)
        {
            Console.WriteLine($"{node.Symbol} - {node.Frequency}");
        }
    }
}


