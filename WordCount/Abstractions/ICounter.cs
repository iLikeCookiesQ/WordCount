using System.Diagnostics.Metrics;

namespace WordCount.Abstractions
{
    public interface ICounter
    {
        public IReadOnlyDictionary<string, int> GetCounts();

        public void AddObservation(string s);
    }
}