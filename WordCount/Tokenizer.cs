namespace WordCount
{
    public class Tokenizer
    {
        public static string[] TokenizeLine(string line)
        {
            var onlyLetters = new String(
                    [.. line
                        .Where(c => char.IsLetter(c) || c == ' ')
                        .Select(c => char.ToLower(c))
                    ]
                );

            return onlyLetters.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
