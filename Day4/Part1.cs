namespace Day4;

public static class Part1
{
    public static int ParseGames(string game)
    {
        var parts = game.Split(':', StringSplitOptions.TrimEntries);
        var numberParts = parts[1].Split("|", StringSplitOptions.TrimEntries);

        var winningNumbers = ParseNumbers(numberParts[0]);
        var numberIHave = ParseNumbers(numberParts[1]);

        var wonNumbers = numberIHave.Intersect(winningNumbers);

        return 1 * (int)Math.Pow(2, wonNumbers.Count() - 1);
    }

    public static List<int> ParseNumbers(string winningNumbers)
    {
        return winningNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }
}
