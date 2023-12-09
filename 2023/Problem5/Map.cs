namespace Problem5;

internal class Map
{
    public static Map Empty = new();

    private readonly List<RangeData> _ranges = [];

    public void AddRange(long destinationRangeStart, long sourceRangeStart, long rangeLength) =>
        _ranges.Add(new RangeData(destinationRangeStart, sourceRangeStart, rangeLength));

    public long GetMap(long number)
    {
        foreach (var range in _ranges)
        {
            if (number >= range.SourceRangeStart
                && number <= range.SourceRangeEnd)
            {
                var offset = number - range.SourceRangeStart;
                return range.DestinationRangeStart + offset;
            }
        }

        return number;
    }
}

public class RangeData(long destinationRangeStart, long sourceRangeStart, long rangeLength)
{
    public long DestinationRangeStart { get; } = destinationRangeStart;

    public long DestinationRangeEnd { get; } = destinationRangeStart + rangeLength - 1;

    public long SourceRangeStart { get; } = sourceRangeStart;

    public long SourceRangeEnd { get; } = sourceRangeStart + rangeLength - 1;

    public long RangeLength { get; } = rangeLength;
}
