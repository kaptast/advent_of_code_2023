namespace Day3;

public static class Part1
{
    private static string symbols = "+-*/#$@=%&";
    private static char[] charactersToTrim = symbols.ToArray().Append('.').ToArray();

    private static int MAXX = 140;
    private static int MAXY = 139;

    public struct Symbol
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Value { get; set; }
    }

    public static long ParseSchematic(List<string> schematic)
    {
        List<Symbol> symbols = new List<Symbol>();
        long sum = 0;

        for (int y = 0; y < schematic.Count; y++)
        {
            for (int x = 0; x < schematic[y].Length; x++)
            {
                if (IsSymbol(schematic[y][x]))
                {
                    symbols.Add(new Symbol { X = x + 1, Y = y, Value = schematic[y][x] });
                }
            }
        }

        for (int i = 0; i < schematic.Count; i++)
        {
            var line = schematic[i];
            var numbers = GetNumbersInLine(line);
            foreach (var number in numbers)
            {
                int x1 = line.IndexOf(number);
                int x2 = x1 + number.Length;
                int y1 = i;
                int y2 = i;

                if (IsSymbolInRange(symbols, x1, y1, x2, y2, MAXX, MAXY, out var foundSymbol))
                {
                    Console.WriteLine($"{number}: {x1} - {y1}: {foundSymbol}");
                    sum += long.Parse(number);
                }
            }
        }

        return sum;
    }

    public static bool IsSymbol(char character)
    {
        return symbols.Contains(character);
    }

    public static string[] GetNumbersInLine(string line)
    {
        var trimmedLine = line;
        foreach (char character in charactersToTrim)
        {
            trimmedLine = trimmedLine.Replace(character, ' ');
        }

        return trimmedLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }

    public static bool IsSymbolInRange(IEnumerable<Symbol> symbols, int x1, int y1, int x2, int y2, int maxX, int maxY, out char foundSymbol)
    {
        foundSymbol = '.';
        int adjustedX1 = x1 - 1 > 0 ? x1 - 1 : 0;
        int adjustedY1 = y1 - 1 > 0 ? y1 - 1 : 0;
        int adjustedX2 = x2 + 1 < maxX ? x2 + 1 : maxX;
        int adjustedY2 = y2 + 1 < maxY ? y2 + 1 : maxY;

        foreach (var symbol in symbols)
        {
            if (symbol.X >= adjustedX1 && symbol.X <= adjustedX2 && symbol.Y >= adjustedY1 && symbol.Y <= adjustedY2)
            {
                foundSymbol = symbol.Value;
                return true;
            }
        }

        return false;
    }
}
