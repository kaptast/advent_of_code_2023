using Day2;

namespace Tests;

public class Day2
{
    [Theory]
    [InlineData("Game 1", 1)]
    [InlineData("Game 4", 4)]
    [InlineData("Game 12", 12)]
    [InlineData("Game 1203", 1203)]
    public void ParsesGameIdCorrectly(string gameId, int expected)
    {
        var result = Part1.ParseGameId(gameId);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("4 red", 4, 0, 0)]
    [InlineData("5 green", 0, 5, 0)]
    [InlineData("3 red", 3, 0, 0)]
    [InlineData("7 blue", 0, 0, 7)]
    [InlineData("999 green", 0, 999, 0)]
    public void ParsesAPullCorrectly(string pull, int expectedRed, int expectedGreen, int expectedBlue)
    {
        var pulls = new Dictionary<string, int>();

        Part1.ParsePull(pulls, pull);

        Assert.Equal(pulls.ContainsKey("red") ? pulls["red"] : 0, expectedRed);
        Assert.Equal(pulls.ContainsKey("green") ? pulls["green"] : 0, expectedGreen);
        Assert.Equal(pulls.ContainsKey("blue") ? pulls["blue"] : 0, expectedBlue);
    }

    [Theory]
    [InlineData("4 red, 5 green, 3 blue", 4, 5, 3)]
    [InlineData("5 green, 12 blue", 0, 5, 12)]
    [InlineData("3 red", 3, 0, 0)]
    [InlineData("7 blue, 999 red", 999, 0, 7)]
    public void ParsesARoundCorrectly(string round, int expectedRed, int expectedGreen, int expectedBlue)
    {
        var pulls = new Dictionary<string, int>();

        Part1.ParseRound(pulls, round);

        Assert.Equal(pulls.ContainsKey("red") ? pulls["red"] : 0, expectedRed);
        Assert.Equal(pulls.ContainsKey("green") ? pulls["green"] : 0, expectedGreen);
        Assert.Equal(pulls.ContainsKey("blue") ? pulls["blue"] : 0, expectedBlue);
    }

    [Theory]
    [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void ParsesAGameCorrectly(string game, bool gamePasses)
    {
        var result = Part1.ParseGame(game);

        Assert.Equal(gamePasses, result);
    }

    [Fact]
    public void ParsingAPullOverritesSmallerValues()
    {
        var pulls = new Dictionary<string, int>
        {
            { "red", 2 },
        };

        Part2.ParsePull(pulls, "4 red");

        Assert.Equal(4, pulls["red"]);
    }

    [Fact]
    public void ParsingAPullDoesntOverriteLargerValues()
    {
        var pulls = new Dictionary<string, int>
        {
            { "green", 10 },
        };

        Part2.ParsePull(pulls, "5 green");

        Assert.Equal(10, pulls["green"]);
    }

    [Theory]
    [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    public void CalculatesThePowerOfAGameCorrectly(string game, int expected)
    {
        var result = Part2.ParseGame(game);

        Assert.Equal(expected, result);
    }
}
