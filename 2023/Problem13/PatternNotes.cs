using System.Data;

using AocUtilities;

namespace Problem13;

internal class PatternNotes
{
    public List<Pattern> Patterns { get; init; } = [];

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

    public long SolvePart2()
    {
        long result = 0;

        foreach (var pattern in Patterns)
        {
            var (Index1, Index2, IsVertical) = FindReflectionWithSmudge(pattern);

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

    private static (int Index1, int Index2, bool IsVertical) FindReflection(Pattern pattern)
    {
        for (int i = 1; i < pattern.VerticalLines.Count; i++)
        {
            var leftIndex = i - 1;
            var rightIndex = i;

            var leftLineArray = pattern.VerticalLines[leftIndex].ToCharArray();
            var rightLineArray = pattern.VerticalLines[rightIndex].ToCharArray();

            if (leftLineArray.SequenceEqual(rightLineArray))
            {
                var leftItems = pattern.VerticalLines[..(leftIndex + 1)];
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

            var bottomLineArray = pattern.HorizontalLines[bottomIndex].ToCharArray();
            var topLineArray = pattern.HorizontalLines[topIndex].ToCharArray();

            if (bottomLineArray.SequenceEqual(topLineArray))
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

    private static (int Index1, int Index2, bool IsVertical) FindReflectionWithSmudge(Pattern pattern)
    {
        var result = (-1, -1, true);
        var smudgeFound = false;

        for (int i = 1; i < pattern.VerticalLines.Count; i++)
        {
            var leftIndex = i - 1;
            var rightIndex = i;

            var difference = GetDifference(
                pattern.VerticalLines[leftIndex],
                pattern.VerticalLines[rightIndex]);

            smudgeFound = difference == 1;

            if (difference == 0 || smudgeFound)
            {
                var leftItems = pattern.VerticalLines[..(leftIndex + 1)];
                leftItems.Reverse();

                var rightItems = pattern.VerticalLines[rightIndex..];

                var min = Math.Min(leftItems.Count, rightItems.Count);
                leftItems = leftItems[..min];
                rightItems = rightItems[..min];

                //var acceptableDifference = smudgeFound
                //    ? Enumerable.Range(0, min).All(index => GetDifference(leftItems[index], rightItems[index]) == 0)
                //    : Enumerable.Range(0, min).Sum(index => GetDifference(leftItems[index], rightItems[index])) == 1;

                if (Enumerable.Range(0, min).Sum(index => GetDifference(leftItems[index], rightItems[index])) == 1)
                {
                    result = (leftIndex, rightIndex, true);
                    break;
                }
            }
        }

        for (int i = 1; i < pattern.HorizontalLines.Count; i++)
        {
            var bottomIndex = i - 1;
            var topIndex = i;

            var difference = GetDifference(
                pattern.HorizontalLines[bottomIndex],
                pattern.HorizontalLines[topIndex]);

            smudgeFound = difference == 1;

            if (difference == 0 || smudgeFound)
            {
                var bottomItems = pattern.HorizontalLines[..(bottomIndex + 1)];
                bottomItems.Reverse();

                var topItems = pattern.HorizontalLines[topIndex..];

                var min = Math.Min(bottomItems.Count, topItems.Count);
                bottomItems = bottomItems[..min];
                topItems = topItems[..min];

                //var acceptableDifference = smudgeFound
                //    ? Enumerable.Range(0, min).All(index => GetDifference(bottomItems[index], topItems[index]) == 0)
                //    : Enumerable.Range(0, min).Sum(index => GetDifference(bottomItems[index], topItems[index])) == 1;

                if (Enumerable.Range(0, min).Sum(index => GetDifference(bottomItems[index], topItems[index])) == 1)
                {
                    result = (bottomIndex, topIndex, false);
                    break;
                }
            }
        }

        return result;
    }

    private static int GetDifference(string first, string second)
    {
        var array1 = first.ToCharArray();
        var array2 = second.ToCharArray();

        int counter = 0;

        for (int i = 0; i < Math.Max(array1.Length, array2.Length); i++)
        {
            if (i >= array1.Length
                || i >= array2.Length
                || array1[i] != array2[i])
            {
                counter++;
            }
        }

        return counter;
    }
}