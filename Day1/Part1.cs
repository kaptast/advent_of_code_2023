namespace Day1;

public static class Part1
{
    public static int SummarizeLine(string line)
    {
        var digits = new List<char>();
        foreach (var digit in line)
        {
            if (char.IsDigit(digit))
            {
                digits.Add(digit);
            }
        }

        var firstDigit = digits.First().ToString();
        var secondDigit = digits.Last().ToString();

        return int.Parse(firstDigit + secondDigit);
    }
}
