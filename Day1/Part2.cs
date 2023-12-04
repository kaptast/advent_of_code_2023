namespace Day1;

public static class Part2
{
    static string[] spelledValues =
    {
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    };

    public static int SummarizeLine(string line)
    {
        var digits = new Dictionary<string, List<int>>();
        for (var i = 0; i < line.Length; i++)
        {
            var digit = line[i];
            if (char.IsDigit(digit))
            {
                StoreDigit(digit.ToString(), i);
            }
        }

        for (var i = 1; i < spelledValues.Length; i++)
        {
            var value = spelledValues[i];
            if (line.Contains(value, StringComparison.InvariantCulture))
            {
                StoreDigit(i.ToString(), line.IndexOf(value, StringComparison.InvariantCulture));
                StoreDigit(i.ToString(), line.LastIndexOf(value, StringComparison.InvariantCulture));
            }
        }

        void StoreDigit(string key, int index)
        {
            if (digits.ContainsKey(key))
            {
                digits[key].Add(index);
            }
            else
            {
                digits.Add(key, new() { index });
            }
        }

        var firstDigit = digits.MinBy(x => x.Value.Min()).Key;
        var secondDigit = digits.MaxBy(x => x.Value.Max()).Key;

        return int.Parse(firstDigit + secondDigit);
    }
}
