using Day3;
using static Day3.Part1;

namespace Tests;

public class Day3
{
    [Theory]
    [InlineData('3', false)]
    [InlineData('a', false)]
    [InlineData('%', true)]
    [InlineData('.', false)]
    [InlineData('*', true)]
    public void IsSymbolReturnsCorrectValue(char symbol, bool expected)
    {
        var result = Part1.IsSymbol(symbol);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("..35..633.", "35", "633")]
    [InlineData(".664.598..", "664", "598")]
    [InlineData("617*......", "617")]
    [InlineData("467..114..", "467", "114")]
    [InlineData("......................667.325*734.................718...............284..*....288..*....620.......854.............643....817....*...........", "667", "325", "734", "718", "284", "288", "620", "854", "643", "817")]
    public void ParsesAllTheNumbersInTheLine(string line, params string[] expected)
    {
        var result = Part1.GetNumbersInLine(line);

        Assert.Equal(expected, result.ToArray());
    }

    static List<Symbol> symbols = new List<Symbol>
    {
        new Symbol { X = 1, Y = 3 },
        new Symbol { X =  6, Y = 6 },
        new Symbol { X = 10, Y = 1 },
        new Symbol { X = 0, Y = 9 },
    };

    [Theory]
    [InlineData(0, 1, 0, 3, true)]
    [InlineData(0, 8, 0, 9, true)]
    [InlineData(7, 4, 7, 5, true)]
    [InlineData(4, 7, 4, 9, false)]
    public void IsSymbolInRangeReturnsCorrectValue(int x1, int y1, int x2, int y2, bool expected)
    {
        var result = Part1.IsSymbolInRange(symbols, x1, y1, x2, y2, 10, 9, out var foundSymbol);

        Assert.Equal(expected, result);
    }
}

