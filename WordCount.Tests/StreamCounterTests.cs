using NSubstitute;
using WordCount.Abstractions;

namespace WordCount.Tests
{
    public class StreamCounterTests
    {
        private readonly string _sampleText = "Lorem ipsum is peak poetry.";

        [Fact]
        public void CorrectlyPassesWordsFromStreamToTokenizer()
        {
            // Arrange
            var line1 = _sampleText;
            var line2 = "Truly marvellous indeed.";
            var input = $"{line1}\n{line2}";

            var inputStream = CreateStreamFromString(input);

            var tokenizerMock = Substitute.For<ITokenizer>();
            var counterMock = Substitute.For<ICounter>();

            var sut = new StreamCounter(tokenizerMock, counterMock);

            // Act
            sut.CountWordsInStream(inputStream);

            // Assert
            tokenizerMock.Received(1).TokenizeLine(line1);
            tokenizerMock.Received(1).TokenizeLine(line2);
            tokenizerMock.Received(2).TokenizeLine(Arg.Any<string>());
        }

        [Fact]
        public void CorrectlyPassesWordsReceivedFromTokenizerToCounter()
        {
            // Arrange
            var inputStream = CreateStreamFromString("a line for the StreamReader");

            var tokenizerMock = Substitute.For<ITokenizer>();
            var counterMock = Substitute.For<ICounter>();

            var returnedFromTokenizer = _sampleText.Split(' ');

            tokenizerMock
                .TokenizeLine(Arg.Any<string>())
                .Returns(returnedFromTokenizer);

            var sut = new StreamCounter(tokenizerMock, counterMock);

            // Act
            sut.CountWordsInStream(inputStream);

            // Assert
            foreach(var token in returnedFromTokenizer)
            {
                counterMock.Received(1).AddObservation(token);
            }

            counterMock
                .Received(returnedFromTokenizer.Length)
                .AddObservation(Arg.Any<string>());
        }

        private Stream CreateStreamFromString(string s)
        {
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(s));
        }
    }
}
