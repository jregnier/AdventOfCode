namespace Problem9;

internal class Sequence
{
    public List<long> Items { get; init; } = [];

    public bool AllZero => Items.All(x => x == 0);

    public long GetLast() => Items[^1];

    public long GetFirst() => Items[0];

    public override string ToString() => string.Join(" ", Items.Select(x => x.ToString()));
}
