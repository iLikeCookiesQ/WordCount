namespace WordCount
{
    internal class Counter
    {
        private readonly SortedDictionary<string, int> counts = new();
        public int TotalCount { get; private set; } = 0;

        public IReadOnlyDictionary<string, int> GetCounts() => counts;

        public void AddObservation(string s)
        {
            ++TotalCount;

            if (!counts.ContainsKey(s))
            {
                counts[s] = 1;
            }
            else
            {
                ++counts[s];
            }
        }
    }
}
