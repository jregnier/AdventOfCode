namespace Problem9;

internal class HistoryItem
{
    public List<Sequence> Sequences { get; init; } = [];

    public static List<HistoryItem> Parse(string input)
    {
        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();

        return inputLines
            .Select(line =>
            {
                var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

                var sequences = GetSequences(values);

                return new HistoryItem { Sequences = sequences };
            })
            .ToList();
    }

    public long ExtrapolateEnd()
    {
        for (int i = Sequences.Count - 1; i >= 0; i--)
        {
            var sequence = Sequences[i];
            if (sequence.AllZero)
            {
                sequence.Items.Add(0);
            }
            else
            {
                sequence.Items.Add(sequence.GetLast() + Sequences[i + 1].GetLast());
            }
        }

        return Sequences[0].GetLast();
    }

    public long ExtrapolateStart()
    {
        for (int i = Sequences.Count - 1; i >= 0; i--)
        {
            var sequence = Sequences[i];
            if (sequence.AllZero)
            {
                sequence.Items.Insert(0, 0);
            }
            else
            {
                sequence.Items.Insert(0, sequence.GetFirst() - Sequences[i + 1].GetFirst());
            }
        }

        return Sequences[0].GetFirst();
    }

    private static List<long> GetDifferences(List<long> items)
    {
        var differences = new List<long>();

        for (var i = 0; i < items.Count - 1; i++)
        {
            differences.Add(items[i + 1] - items[i]);
        }

        return differences;
    }

    private static List<Sequence> GetSequences(List<long> items)
    {
        var result = new List<Sequence>();

        var seq = new Sequence { Items = items };
        result.Add(seq);

        while (!seq.AllZero)
        {
            var diff = GetDifferences(seq.Items);
            seq = new Sequence { Items = diff };
            result.Add(seq);
        }

        return result;
    }
}