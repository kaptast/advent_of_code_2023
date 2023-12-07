namespace Day5;


public static class Part1
{
    public static long Solve(string[] lines)
    {
        long closestLocation = long.MaxValue;
        var categories = new List<Category>();

        var seeds = lines[0].Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

        for (long i = 2; i < lines.Length; i++)
        {
            var line = lines[i];
            switch (line)
            {
                case var a when line.EndsWith("map:"):
                    categories.Add(new Category());
                    break;
                case "":
                    continue;
                default:
                    categories.Last().Add(line);
                    break;
            }
        }

        foreach (var seed in seeds)
        {
            var result = Map(seed, categories);
            if (result < closestLocation)
            {
                closestLocation = result;
            }
        }

        return closestLocation;
    }

    public static long Map(long seed, List<Category> categories)
    {
        var mappedSeed = seed;

        foreach (var category in categories)
        {
            mappedSeed = category.Map(mappedSeed);
        }

        return mappedSeed;
    }
}

public static class Part2
{
    public static long Solve(string[] lines)
    {
        long closestLocation = long.MaxValue;
        var categories = new List<Category>();
        var seeds = new List<Seed>();


        var seedParts = lines[0].Split(':', StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        for (int i = 0; i < seedParts.Count; i += 2)
        {
            seeds.Add(new Seed
            {
                Start = seedParts[i],
                Distance = seedParts[i + 1]
            });
        }

        for (int i = 2; i < lines.Length; i++)
        {
            var line = lines[i];
            switch (line)
            {
                case var a when line.EndsWith("map:"):
                    categories.Add(new Category());
                    break;
                case "":
                    continue;
                default:
                    categories.Last().Add(line);
                    break;
            }
        }

        foreach (var seed in seeds)
        {
            for (long i = 0; i < seed.Distance; i++)
            {
                var result = Map(seed.Start + i, categories);
                if (result < closestLocation)
                {
                    closestLocation = result;
                    Console.WriteLine(closestLocation);
                }
            }
        }

        return closestLocation;
    }

    public static long Map(long seed, List<Category> categories)
    {
        var mappedSeed = seed;

        foreach (var category in categories)
        {
            mappedSeed = category.Map(mappedSeed);
        }

        return mappedSeed;
    }
}

public class Seed
{
    public long Start { get; set; } = 0;
    public long Distance { get; set; } = 0;
}


public class Category
{
    List<Range> ranges = new List<Range>();

    public void Add(string line)
    {
        ranges.Add(new Range(line));
    }

    public long Map(long source)
    {
        foreach (Range range in ranges)
        {
            var result = range.Map(source);
            if (result != source)
            {
                return result;
            }
        }

        return source;
    }
}

public class Range
{
    long source;
    long destination;
    long length;

    public Range(string line)
    {
        var parts = line.Split(' ');
        destination = long.Parse(parts[0]);
        source = long.Parse(parts[1]);
        length = long.Parse(parts[2]);
    }

    public long Map(long source)
    {
        if (this.source <= source && source <= this.source + length - 1)
        {
            return source - this.source + destination;
        }

        return source;
    }
}
