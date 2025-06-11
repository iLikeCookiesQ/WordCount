using WordCount.Abstractions;

namespace WordCount
{
    public class StreamCounter
    {
        private readonly ITokenizer _tokenizer;
        private readonly ICounter _counter;

        public StreamCounter(ITokenizer tokenizer, ICounter counter)
        {
            _tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
            _counter = counter ?? throw new ArgumentNullException(nameof(counter));
        }

        public void CountWordsInStream(Stream stream)
        {
            using var reader = new StreamReader(stream);

            string? line = reader.ReadLine();

            while(line != null)
            {
                var words = _tokenizer.TokenizeLine(line);

                foreach (var word in words)
                {
                    _counter.AddObservation(word);
                }

                line = reader.ReadLine();
            }
        }
    }
}
