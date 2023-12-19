using System.Data;

using AocUtilities;

namespace Problem13;

internal class PatternNotes
{
    public List<Pattern> Patterns { get; init; } = [];

    private static (int Index1, int Index2, bool IsVertical) FindReflection(Pattern pattern)
    {
        for (int i = 1; i < pattern.VerticalLines.Count; i++)
        {
            var leftIndex = i - 1;
            var rightIndex = i;

            if (pattern.VerticalLines[leftIndex].Equals(pattern.VerticalLines[rightIndex]))
            {
                var leftItems = pattern.VerticalLines[.. (leftIndex + 1)];
                leftItems.Reverse();

                var rightItems = pattern.VerticalLines[rightIndex..];

                var min = Math.Min(leftItems.Count, rightItems.Count);
                leftItems = leftItems[..min];
                rightItems = rightItems[..min];

                if (leftItems.SequenceEqual(rightItems))
                {
                    return (leftIndex, rightIndex, true);
                }
            }
        }

        for (int i = 1; i < pattern.HorizontalLines.Count; i++)
        {
            var bottomIndex = i - 1;
            var topIndex = i;

            if (pattern.HorizontalLines[bottomIndex].Equals(pattern.HorizontalLines[topIndex]))
            {
                var bottomItems = pattern.HorizontalLines[..(bottomIndex + 1)];
                bottomItems.Reverse();

                var topItems = pattern.HorizontalLines[topIndex..];

                var min = Math.Min(bottomItems.Count, topItems.Count);
                bottomItems = bottomItems[..min];
                topItems = topItems[..min];

                if (bottomItems.SequenceEqual(topItems))
                {
                    return (bottomIndex, topIndex, false);
                }
            }
        }

        return (-1, -1, false);
    }

    public long SolvePart1()
    {
        long result = 0;

        foreach (var pattern in Patterns)
        {
            var (Index1, Index2, IsVertical) = FindReflection(pattern);

            if (IsVertical)
            {
                result += Index1 + 1;
            }
            else
            {
                result += (Index1 + 1) * 100;
            }
        }

        return result;
    }

    public static PatternNotes Parse(string input)
    {
        var sections = InputReader.GetText(input)
            .Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var patterns = sections
            .Select(x =>
            {
                var (rows, columns) = InputReader.GetRowsAndColumns(x);
                return new Pattern([.. columns], [.. rows]);
            })
            .ToList();

        return new PatternNotes
        {
            Patterns = patterns,
        };
    }
}
