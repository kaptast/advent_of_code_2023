using System.Text.RegularExpressions;

namespace Day3;

public static class Part1
{
    private static string symbols = "+-*/#$@=%&";
    private static char[] charactersToTrim = symbols.ToArray().Append('.').ToArray();

    public struct Symbol
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Value { get; set; }
    }

    public static void DrawSchematic(List<string> schematic)
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        foreach (string s in schematic)
        {
            foreach (char c in s)
            {
                if (IsSymbol(c))
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(c);
                }
                else if (c == '.')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(' ');
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan; 
                    Console.Write(c);
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine();
        }
    }

    public static async Task<long> ParseSchematic(List<string> schematic)
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        List<Symbol> symbols = new List<Symbol>();
        long sum = 0;

        for (int y = 0; y < schematic.Count; y++)
        {
            for (int x = 0; x < schematic[y].Length; x++)
            {
                if (IsSymbol(schematic[y][x]))
                {
                    symbols.Add(new Symbol { X = x, Y = y, Value = schematic[y][x] });
                }
            }
        }

        foreach (Symbol symbol in symbols)
        {
            Console.SetCursorPosition(symbol.X, symbol.Y);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(symbol.Value);
        }

        for (int i = 0; i < schematic.Count; i++)
        {
            long sumForLine = 0;
            long allTheMatchesInTheLine = 0;

            var line = schematic[i];
            var numbers = GetNumbersInLine(line);
            foreach (var number in numbers)
            {
                var pattern = new Regex($"(^|\\D){number}(\\D|$)");
                var matches = pattern.Matches(line).ToList();

                foreach (var match in matches)
                {
                    allTheMatchesInTheLine += long.Parse(match.Value.Trim(charactersToTrim));
                    int x1 = char.IsDigit(match.Value[0]) ? match.Index : match.Index + 1;
                    int x2 = x1 + number.Length - 1;
                    int y = i;

                    if (IsSymbolInRange(symbols, x1, x2, y, out var foundSymbol))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(foundSymbol!.Value.X, foundSymbol.Value.Y);
                        Console.Write(foundSymbol.Value.Value);
                        Console.BackgroundColor = ConsoleColor.Green;
                        
                        sumForLine += long.Parse(number);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.SetCursorPosition(x1, y);
                    Console.Write(number);
                    Console.ForegroundColor = ConsoleColor.White;

                    await Task.Delay(1);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            if (sumForLine < allTheMatchesInTheLine)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }

            Console.SetCursorPosition(150, i);
            Console.Write($"Matches: {sumForLine} - All numbers: {allTheMatchesInTheLine}");
            Console.BackgroundColor = ConsoleColor.Black;

            sum += sumForLine;
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

        return trimmedLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
    }

    public static bool IsSymbolInRange(IEnumerable<Symbol> symbols, int x1, int x2, int y, out Symbol? foundSymbol)
    {
        foundSymbol = null;
        int adjustedX1 = x1 - 1 > 0 ? x1 - 1 : 0;
        int adjustedY1 = y - 1 > 0 ? y - 1 : 0;
        int adjustedX2 = x2 + 1;
        int adjustedY2 = y + 1;

        foreach (var symbol in symbols)
        {
            if (symbol.X >= adjustedX1 && symbol.X <= adjustedX2 && symbol.Y >= adjustedY1 && symbol.Y <= adjustedY2)
            {
                foundSymbol = symbol;
                return true;
            }
        }

        return false;
    }
}
