namespace Day1;

public static class Part1
{
    public static int SummarizeLine(string line)
    {
        int? firstDigit = null, secondDigit = null;

        foreach (var character in line)
        {
            if (char.IsDigit(character))
            {
                firstDigit ??= int.Parse(character.ToString());
                secondDigit = int.Parse(character.ToString());
            }
        }

        return firstDigit.GetValueOrDefault() * 10 + secondDigit.GetValueOrDefault();
    }
}
