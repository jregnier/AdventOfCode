namespace Problem7;

internal class Hand : IComparable<Hand>
{
    public static List<char> CARD_VALUES =
    [
        'A',
        'K',
        'Q',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2',
        'J',
    ];

    public Hand(List<Card> cards, long bidAmount)
    {
        Cards = cards;
        BidAmount = bidAmount;

        HandType = GetHandTypeWithWildCard();
    }

    public long BidAmount { get; }

    public List<Card> Cards { get; } = [];

    public HandType HandType { get; } = HandType.None;

    public int Rank { get; set; }

    public static List<Hand> Parse(string input)
    {
        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();

        var result = new List<Hand>();
        foreach (var line in inputLines)
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var cards = parts[0].ToCharArray()
                .Select(x => new Card { Value = x, Power = CARD_VALUES.IndexOf(x) })
                .ToList();
            var bid = long.Parse(parts[1]);

            result.Add(new Hand(cards, bid));
        }

        return result
            .OrderByDescending(x => x)
            .Select((item, index) =>
            {
                item.Rank = index + 1;
                return item;
            })
            .ToList();
    }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (HandType == other.HandType)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                var card = Cards[i];
                var otherCard = other.Cards[i];

                if (card.Power == otherCard.Power)
                {
                    continue;
                }

                return card.Power > otherCard.Power
                    ? 1
                    : -1;
            }
        }

        return HandType.CompareTo(other.HandType);
    }

    public long GetWinnings() => BidAmount * Rank;

    public override string ToString() => HandType.ToString() + " " + string.Join("", Cards);

    private HandType GetHandType()
    {
        var groups = Cards.GroupBy(x => x.Value).ToList();

        if (groups.Any(x => x.Count() == 5))
        {
            return HandType.FiveOfAKind;
        }

        if (groups.Any(x => x.Count() == 4))
        {
            return HandType.FourOfAKind;
        }

        if (groups.Any(x => x.Count() == 3)
            && groups.Any(x => x.Count() == 2))
        {
            return HandType.FullHouse;
        }

        if (groups.Any(x => x.Count() == 3))
        {
            return HandType.ThreeOfAKind;
        }

        var pairs = groups.Where(x => x.Count() == 2);

        if (pairs.Count() == 2)
        {
            return HandType.TwoPair;
        }

        if (pairs.Count() == 1)
        {
            return HandType.OnePair;
        }

        if (groups.Count == 5)
        {
            return HandType.HighCard;
        }

        return HandType.None;
    }

    private HandType GetHandTypeWithWildCard()
    {
        var jCardNum = Cards.Count(x => x.Value == 'J');
        var groups = Cards
            .GroupBy(x => x.Value)
            .Where(x => x.Key != 'J')
            .ToList();

        if (groups.Any(x => x.Count() + jCardNum == 5)
            || jCardNum == 5)
        {
            return HandType.FiveOfAKind;
        }

        if (groups.Any(x => x.Count() + jCardNum == 4))
        {
            return HandType.FourOfAKind;
        }

        var triples = groups.Find(x => x.Count() + jCardNum == 3);

        if (triples != null
            && groups.Any(x => x.Count() == 2 && x.Key != triples.Key))
        {
            return HandType.FullHouse;
        }

        if (groups.Any(x => x.Count() + jCardNum == 3))
        {
            return HandType.ThreeOfAKind;
        }

        var pairsCount = groups.Count(x => x.Count() == 2);

        if (pairsCount == 2
            || (pairsCount == 1 && jCardNum == 1))
        {
            return HandType.TwoPair;
        }

        if (pairsCount == 1
            || (pairsCount == 0 && jCardNum == 1))
        {
            return HandType.OnePair;
        }

        if (groups.Count == 5)
        {
            return HandType.HighCard;
        }

        return HandType.None;
    }
}

public enum HandType
{
    FiveOfAKind = 0,
    FourOfAKind = 1,
    FullHouse = 2,
    ThreeOfAKind = 3,
    TwoPair = 4,
    OnePair = 5,
    HighCard = 6,
    None = 100,
}