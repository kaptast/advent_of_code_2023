namespace Day2;

public static class Part2
{
    public static int ParseGames(string game)
    {
        return ParseGame(game.Split(":")[1]);
    }

    public static void ParsePull(Dictionary<string, int> pulls, string pull)
    {
        var parts = pull.Split(" ");

        var numberOfCubes = int.Parse(parts[0]);
        var color = parts[1];

        if (pulls[color] < numberOfCubes)
        {
            pulls[color] = numberOfCubes;
        }
    }

    public static void ParseRound(Dictionary<string, int> pulls, string round)
    {
        var pullsInRound = round.Split(",", StringSplitOptions.TrimEntries);

        foreach (var pull in pullsInRound)
        {
            ParsePull(pulls, pull);
        }
    }

    public static int ParseGame(string game)
    {
        var rounds = game.Split(";", StringSplitOptions.TrimEntries);

        var pulls = new Dictionary<string, int>()
        {
            {"red", 0 },
            {"green", 0 },
            {"blue", 0 },
        };

        foreach (var round in rounds)
        {
            ParseRound(pulls, round);
        }

        return pulls["red"] * pulls["green"] * pulls["blue"];
    }
}
