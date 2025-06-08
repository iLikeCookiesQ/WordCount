using System.Diagnostics;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var lines = File.ReadAllLines("..\\..\\..\\input.txt");

            var counter = new Counter();

            foreach (var line in lines)
            {
                var words = Tokenizer.TokenizeLine(line);

                foreach (var word in words)
                {
                    counter.AddObservation(word);
                }
            }

            Console.WriteLine("Number of words: " + counter.TotalCount + "\n");

            foreach (var kvp in counter.GetCounts())
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}
