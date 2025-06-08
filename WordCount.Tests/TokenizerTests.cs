namespace WordCount.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void SpecialCharactersAndNumbersAreIgnored()
        {
            // Arrange
            var input = "hi124567890!@#$%^&*()ya";

            // Act
            var result = Tokenizer.TokenizeLine(input);

            // Assert
            Assert.Equal("hiya", result[0]);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("  ", 0)]
        [InlineData("one two three", 3)]
        [InlineData("one two three four", 4)]
        [InlineData("one two three four five", 5)]
        public void TheNumberOfWordsInALineIsCorrect(string input, int expectedCount)
        {
            // Act
            var result = Tokenizer.TokenizeLine(input);

            // Assert
            Assert.Equal(expectedCount, result.Length);
        }

        [Fact]
        public void ResultWordsAreLowerCased()
        {
            // Arrange
            var input = "I think Jack did a better job than John. ";

            // Act
            var result = Tokenizer.TokenizeLine(input);

            // Assert
            Assert.Equal("i", result[0]);
            Assert.Equal("jack", result[2]);
            Assert.Equal("john", result[8]);
        }
    }
}