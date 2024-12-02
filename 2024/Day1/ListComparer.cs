using System;
using AocUtilities;

namespace Day1;

public class ListComparer
{
    public List<long> List1 { get; init; } = [];

    public List<long> List2 { get; init; } = [];

    public long Solve1()
    {
        var minCount = Math.Min(List1.Count, List2.Count);
        var sortedList1 = List1.OrderBy(x => x).ToArray();
        var sortedList2 = List2.OrderBy(x => x).ToArray();

        long result = 0;

        for (int i = 0; i < Math.Max(List1.Count, List2.Count); i++)
        {
            if (i >= minCount)
            {
                break;
            }

            result += Math.Abs(sortedList1[i] - sortedList2[i]);
        }

        return result;
    }

    public long Solve2()
    {
        long result = 0;
        var list2Lookup = List2
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        foreach (var item in List1)
        {
            if (list2Lookup.TryGetValue(item, out var amount))
            {
                result += item * amount;
            }
        }

        return result;
    }

    public static ListComparer Parse(string content)
    {
        var list1 = new List<long>();
        var list2 = new List<long>();

        foreach (var line in InputReader.GetLines(content))
        {
            var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (split != null)
            {
                list1.Add(long.Parse(split[0]));
                list2.Add(long.Parse(split[1]));
            }
        }

        return new ListComparer
        {
            List1 = list1,
            List2 = list2,
        };
    }

}
