using Day1;

namespace Tests;

public class Day1
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void LineMatchesDigits(string pattern, int expected)
    {
        var result = Part1.SummarizeLine(pattern);

        Assert.Equal(expected, result);
    }
}