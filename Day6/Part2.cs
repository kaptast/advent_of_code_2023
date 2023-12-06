namespace Day6;

public static class Part2
{
    public static long Solve(string[] lines)
    {
        var time = ReadLine(lines[0]);
        var record = ReadLine(lines[1]);

        var solutions = 0;

        for (long holdTime = 1; holdTime <= time; holdTime++)
        {
            var distance = (time - holdTime) * holdTime;
            if (distance > record)
            {
                solutions++;
            }
        }

        return solutions;
    }

    public static long ReadLine(string line)
    {
        var parts = line.Split(':', StringSplitOptions.TrimEntries);

        return long.Parse(parts[1].Replace(" ", ""));
    }
}
