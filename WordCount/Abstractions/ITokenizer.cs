namespace WordCount.Abstractions
{
    public interface ITokenizer
    {
        public string[] TokenizeLine(string line);
    }
}