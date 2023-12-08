using Day7;

var lines = File.ReadLines("input.txt");

var hands = new List<Hand>();

foreach (var line in lines)
{
    hands.Add(new Hand(line));
}

hands.Sort();

var winnings = 0;

for (int i = 0; i < hands.Count; i++)
{
    winnings += (i + 1) * hands[i].Bet;
}

Console.WriteLine(winnings);