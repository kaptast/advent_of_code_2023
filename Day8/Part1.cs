using System.Text.RegularExpressions;

namespace Day8;

internal class Map
{
    Dictionary<string, Node> map = new Dictionary<string, Node>();

    public void Add(string line)
    {
        var parts = line.Split('=', StringSplitOptions.TrimEntries);
        map.Add(parts[0], new Node(parts[1]));
    }

    public ulong Traverse(string steps)
    {
        ulong numberOfSteps = 0;
        int currentStepIndex = 0;
        var currentNodeKey = "AAA";
        
        while (currentNodeKey != "ZZZ")
        {
            numberOfSteps++;
            currentNodeKey = map[currentNodeKey].GetDirection(steps[currentStepIndex++]);

            if (currentStepIndex >= steps.Length)
            {
                currentStepIndex = 0;
            }
        }

        return numberOfSteps;
    }
}

internal class Node
{
    string left, right;

    public Node(string directions)
    {
        directions = Regex.Replace(directions, "[()]", "");
        var parts = directions.Split(',', StringSplitOptions.TrimEntries);

        left = parts[0];
        right = parts[1];
    }

    public string GetDirection(char direction)
    {
        return direction switch
        {
            'L' => left,
            'R' => right,
            _ => throw new ArgumentException(),
        };
    }
}
