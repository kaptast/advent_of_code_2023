namespace Day2;

public static class Part1
{
    static int maximumNumberOfRedCubes = 12;
    static int maximumNumberOfGreenCubes = 13;
    static int maximumNumberOfBlueCubes = 14;

    public static int ParseGames(string game)
    {
        var parts = game.Split(":");
        if (ParseGame(parts[1]))
        {
            return ParseGameId(parts[0]);
        }

        return 0;
    }

    public static int ParseGameId(string game)
    {
        var parts = game.Split(' ');

        return int.Parse(parts[1]);
    }

    public static void ParsePull(Dictionary<string, int> pulls, string pull)
    {
        var parts = pull.Split(" ");

        var numberOfCubes = int.Parse(parts[0]);
        var color = parts[1];

        if (pulls.ContainsKey(color))
        {
            pulls[color] += numberOfCubes;
        }
        else
        {
            pulls.Add(color, numberOfCubes);
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

    public static bool ParseGame(string game)
    {
        var rounds = game.Split(";", StringSplitOptions.TrimEntries);

        foreach (var round in rounds)
        {
            var pulls = new Dictionary<string, int>();
            ParseRound(pulls, round);
            if (!RoundPasses(pulls))
            {
                return false;
            }
        }

        return true;
    }

    public static bool RoundPasses(Dictionary<string, int> pulls)
    {
        if (pulls.TryGetValue("red", out var numberOfRedCubes))
        {
            if (numberOfRedCubes > maximumNumberOfRedCubes)
            {
                return false;
            }
        }

        if (pulls.TryGetValue("green", out var numberOfGreenCubes))
        {
            if (numberOfGreenCubes > maximumNumberOfGreenCubes)
            {
                return false;
            }
        }

        if (pulls.TryGetValue("blue", out var numberOfBlueCubes))
        {
            if (numberOfBlueCubes > maximumNumberOfBlueCubes)
            {
                return false;
            }
        }

        return true;    
    }
}
