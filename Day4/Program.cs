using Day4;

int SummarizeLines(Func<string, int> solver)
{
    var lines = File.ReadAllLines("input.txt");

    var sum = 0;

    foreach (var line in lines)
    {
        sum += solver(line);
    }

    return sum;
}

Console.WriteLine(SummarizeLines(Part1.ParseGames));


Console.WriteLine(Part2.ParseGames());