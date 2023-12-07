namespace Tests;

using global::Day5;

public class Day5
{
    [Theory]
    [InlineData("50 98 2", 99, 51)]
    [InlineData("50 98 2", 98, 50)]
    [InlineData("50 98 2", 100, 100)]
    [InlineData("50 98 2", 50, 50)]
    public void RangeMapsValuesCorrectly(string input, int source, int expected)
    {
        var range = new Range(input);

        var result = range.Map(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(99, 51, "50 98 2", "52 50 48")]
    [InlineData(98, 50, "50 98 2", "52 50 48")]
    [InlineData(100, 100, "50 98 2", "52 50 48")]
    [InlineData(50, 52, "50 98 2", "52 50 48")]
    [InlineData(53, 55, "50 98 2", "52 50 48")]
    [InlineData(79, 81, "50 98 2", "52 50 48")]
    [InlineData(14, 14, "50 98 2", "52 50 48")]
    [InlineData(55, 57, "50 98 2", "52 50 48")]
    [InlineData(13, 13, "50 98 2", "52 50 48")]
    public void CategoryMapsValuesCorrectly(int source, int expected, params string[] ranges)
    {
        var category = new Category();
        foreach(var range in ranges)
        {
            category.Add(range);
        }

        var result = category.Map(source);

        Assert.Equal(expected, result);
    }

}
