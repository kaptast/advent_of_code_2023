namespace Day6;

public static class Part1
{
    public static int Solve(string[] lines)
    {
        var times = ReadLine(lines[0]);
        var records = ReadLine(lines[1]);

        var allTheSolutions = 1;

        for (int i = 0; i < times.Count; i++)
        {
            var solutions = 0;

            var time = times[i];
            var record = records[i];

            for (int holdTime = 1; holdTime <= time; holdTime++)
            {
                var distance = (time - holdTime) * holdTime;
                if (distance > record)
                {
                    solutions++;
                }
            }

            allTheSolutions *= solutions;
        }

        return allTheSolutions;
    }

    public static List<int> ReadLine(string line)
    {
        var parts = line.Split(':', StringSplitOptions.TrimEntries);

        return parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }
}
