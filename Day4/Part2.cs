namespace Day4;

public static class Part2
{
    public static int ParseGames()
    {
        var lines = File.ReadAllLines("input.txt").ToList();

        for (var i = 0; i < lines.Count; i++)
        {
            var result = ParseGame(lines[i]);

            var linesToAdd = new List<string>();
            for (var j = 1; j <= result; j++)
            {
                var index = 2 * j + i;
                linesToAdd.Add(lines[index]);
            }

            for (var j = 1; j <= result; j++)
            {
                lines.Insert(2 * j + i, linesToAdd[j - 1]);
            }
        }

        return lines.Count;
    }

    public static int ParseGame(string game)
    {
        var parts = game.Split(':', StringSplitOptions.TrimEntries);
        var numberParts = parts[1].Split("|", StringSplitOptions.TrimEntries);

        var winningNumbers = ParseNumbers(numberParts[0]);
        var numberIHave = ParseNumbers(numberParts[1]);

        var wonNumbers = numberIHave.Intersect(winningNumbers);

        return wonNumbers.Count();
    }

    public static List<int> ParseNumbers(string winningNumbers)
    {
        return winningNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }
}
