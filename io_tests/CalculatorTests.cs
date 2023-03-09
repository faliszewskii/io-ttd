using FluentAssertions;
using io_ttd;

namespace io_tests
{
    public class CalculatorTests
    {
        private readonly StringCalculator _calculator = new StringCalculator();

        [Theory]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        public void ReturnZero_WhenEmptyOrWhitespaceString(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData("10", 10)]
        [InlineData("-5", -5)]
        [InlineData("0", 0)]
        public void ReturnTheSameNumber_WhenOneNumberString(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData("2,3", 5)]
        [InlineData("2,5,1", 8)]
        public void ReturnSum_WhenStringOfNumbersSplitByComma(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData("2\n3", 5)]
        [InlineData("2\n5\n1", 8)]
        public void ReturnSum_WhenStringOfNumbersSplitByNewLine(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData("2\n3,0", 5)]
        [InlineData("2,5\n1", 8)]
        public void ReturnSum_WhenStringOfNumbersSplitByMixed(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData("fjdl", 5)]
        [InlineData("2,5-1", 8)]
        public void ThrowInvalidArgumentException_WhenStringInInvalidFormat(string input, int expected)
        {
            
            var lambda = () =>_calculator.Add(input);
            lambda.Should().Throw<ArgumentException>();
        }
        
        [Theory]
        [InlineData("42, 1, 6", 7)]
        public void ReturnSumIgnoring42_WhenStringOfNumbersWith42(string input, int expected)
        {
            int result = _calculator.Add(input);
            result.Should().Be(expected);
        }
    }
}