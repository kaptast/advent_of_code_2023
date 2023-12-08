namespace Day7;

public class Hand: IComparable<Hand>
{
    List<Card> cards = new List<Card>();
    int value = 0;

    public string CardsInHand { get; init; }

    public List<Card> Cards { get { return cards; } }

    public int Value
    {
        get
        {
            if (value == 0)
            {
                value = Catogrize();
            }

            return value;
        }
    }

    public int Bet { get; init; }

    public Hand(string hand)
    {
        var parts = hand.Split(' ');
        foreach (var card in parts[0])
        {
            cards.Add(new Card(card));
        }

        Bet = int.Parse(parts[1]);
        CardsInHand = parts[0];
    }

    private int Catogrize()
    {


        if (Is5OfAKind())
        {
            return 30000;
        }

        if (Is4OfAKind() )
        {
            return 25000;
        }

        if (IsFullHouse())
        {
            return 20000;
        }

        if (Is3OfAKind())
        {
            return 15000;
        }

        if (Is2Pairs())
        {
            return 10000;
        }

        if (Is1Pair())
        {
            return 5000;
        }

        return 0;
    }

    private bool Is5OfAKind()
    {
        return cards.DistinctBy(x => x.Value).Count() == 1;
    }

    private bool Is4OfAKind()
    {
        var groups = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());

        if (groups is null || groups.Count() != 2)
        {
            return false;
        }

        return groups.First().Count() == 4 && groups.Last().Count() == 1;
    }

    private bool IsFullHouse()
    {
        var groups = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());

        if (groups is null || groups.Count() != 2)
        {
            return false;
        }

        return groups.First().Count() == 3 && groups.Last().Count() == 2;
    }

    private bool Is3OfAKind()
    {
        var groups = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());

        if (groups is null || groups.Count() != 3)
        {
            return false;
        }

        return groups.First().Count() == 3 && groups.Last().Count() == 1;
    }

    private bool Is2Pairs()
    {
        var groups = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());

        if (groups is null || groups.Count() != 3)
        {
            return false;
        }

        return groups.First().Count() == 2 && groups.ElementAt(1).Count() == 2 && groups.Last().Count() == 1;
    }

    private bool Is1Pair()
    {
        var groups = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());

        if (groups is null || groups.Count() != 4)
        {
            return false;
        }

        return groups.First().Count() == 2 && groups.Last().Count() == 1;
    }

    public int CompareTo(Hand? other)
    {
        if (other is null)
        {
            return 1;
        }

        if (this.Value == other.Value)
        {
            for (var i = 0; i < Cards.Count(); i++)
            {
                var currentValue = Cards[i].Value;
                var otherValue = other.Cards[i].Value;

                if (currentValue != otherValue)
                {
                    return currentValue > otherValue ? 1 : -1;
                }
            }
        }

        return this.Value > other.Value ? 1 : -1;
    }
}

public class Card
{
    static Dictionary<char, int> cardValueMap = new()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
    };

    public int Value { get; init; }

    public Card(char symbol)
    {
        Value = cardValueMap[symbol];
    }
}
