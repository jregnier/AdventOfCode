namespace Problem4;

internal class Card
{
    public int CardNumber { get; init; }

    public List<Card> Copies { get; set; } = [];

    public List<int> MatchingNumbers { get; init; } = [];

    public List<int> MyNumbers { get; init; } = [];

    public int Points { get; private set; }

    public List<int> WinningNumbers { get; init; } = [];

    public static List<Card> Parse(List<string> lines) =>
        lines.ConvertAll(ParseLine);

    public void CalculatePoints()
    {
        foreach (var _ in MatchingNumbers)
        {
            if (Points == 0)
            {
                Points = 1;
            }
            else
            {
                Points *= 2;
            }
        };
    }

    public Card Copy() => new()
    {
        CardNumber = CardNumber,
        WinningNumbers = WinningNumbers,
        MyNumbers = MyNumbers,
        MatchingNumbers = MatchingNumbers,
    };

    public int GetTotalCount()
    {
        var total = 1;

        foreach (var item in Copies)
        {
            total += item.GetTotalCount();
        }

        return total;
    }

    private static Card ParseLine(string line)
    {
        var cardPart = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
        var cardNumber = int.Parse(cardPart[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

        var numberSplit = cardPart[1].Split("|", StringSplitOptions.RemoveEmptyEntries);

        var winningNumbers = numberSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var myNumbers = numberSplit[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        return new Card
        {
            CardNumber = cardNumber,
            WinningNumbers = winningNumbers,
            MyNumbers = myNumbers,
            MatchingNumbers = winningNumbers.Intersect(myNumbers).ToList(),
        };
    }
}