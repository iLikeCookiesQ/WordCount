using WordCount.Abstractions;

namespace WordCount
{
    public class Counter : ICounter
    {
        private readonly SortedDictionary<string, int> _counts = new();
        public int TotalCount { get; private set; } = 0;

        public IReadOnlyDictionary<string, int> GetCounts() => _counts;

        public void AddObservation(string s)
        {
            ++TotalCount;

            if (!_counts.ContainsKey(s))
            {
                _counts[s] = 1;
            }
            else
            {
                ++_counts[s];
            }
        }
    }
}
