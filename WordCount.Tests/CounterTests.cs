using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    public class CounterTests
    {
        private Counter _counter = new();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TotalCountIncrementsCorrectly(int numberOfObservations)
        {
            // Act
            for (int i = 0; i < numberOfObservations; ++i)
            {
                _counter.AddObservation("heh");
            }

            // Assert
            Assert.Equal(numberOfObservations, _counter.TotalCount);
        }

        [Fact]
        public void CountsAreCorrecltyTrackedPerWord()
        {
            // Arrange
            var inputs = new List<string> { "one", "two", "two", "three", "three", "three" };

            // Act 
            foreach (var input in inputs)
            {
                _counter.AddObservation(input);
            }

            var result = _counter.GetCounts();

            // Assert
            Assert.Equal(1, result["one"]);
            Assert.Equal(2, result["two"]);
            Assert.Equal(3, result["three"]);
        }
    }
}
