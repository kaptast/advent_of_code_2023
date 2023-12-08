using Day8;

var lines = File.ReadAllLines("input.txt");

var steps = lines[0];
var map = new Map();

for (int i = 2; i < lines.Length; i++)
{
    map.Add(lines[i]);
}

Console.WriteLine(map.Traverse(steps));