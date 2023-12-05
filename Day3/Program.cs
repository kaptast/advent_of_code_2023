using Day3;

var lines = File.ReadLines("input.txt");
Part1.DrawSchematic(lines.ToList());
var result = await Part1.ParseSchematic(lines.ToList());
Console.WriteLine();
Console.WriteLine(result);