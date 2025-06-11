using System.Diagnostics;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length == 0
                ? "..\\..\\..\\input.txt"
                : args[0];

            var tokenizer = new Tokenizer();
            var counter = new Counter();

            var streamCounter = new StreamCounter(tokenizer, counter);
            streamCounter.CountWordsInStream(File.OpenRead(path));

            Console.WriteLine("Number of words: " + counter.TotalCount + "\n");

            foreach (var kvp in counter.GetCounts())
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}
