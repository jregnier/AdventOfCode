using System.Data;

namespace Day10;

internal class AreaMap
{
    public List<List<int>> Map { get; set; } = [];

    public static AreaMap Parse(string content)
    {
        var charMap = AocUtilities.InputReader.GetMapAsList(content);

        var intMap = new List<List<int>>();

        foreach (var row in charMap)
        {
            var values = new List<int>();
            foreach (var col in row)
            {
                values.Add(int.Parse(col.ToString()));
            }

            intMap.Add(values);
        }

        return new AreaMap
        {
            Map = intMap
        };
    }

    public long Solve1()
    {
        long total = 0;

        for (int row = 0; row < Map.Count; row++)
        {
            for (int col = 0; col < Map[row].Count; col++)
            {
                if (Map[row][col] == 0)
                {
                    var trails = FindTrails((row, col));
                    var distictEnds = trails
                        .Select(x => x[^1])
                        .ToHashSet();

                    total += distictEnds.Count;
                }
            }
        }

        return total;
    }

    public long Solve2()
    {
        long total = 0;

        for (int row = 0; row < Map.Count; row++)
        {
            for (int col = 0; col < Map[row].Count; col++)
            {
                if (Map[row][col] == 0)
                {
                    var trails = FindTrails((row, col));
                    var rating = trails.Count;

                    total += rating;
                }
            }
        }

        return total;
    }

    private List<(int Row, int Col)[]> FindTrails((int Row, int Col) coordinate) =>
            FindTrails(coordinate, 1, [coordinate]);

    private List<(int Row, int Col)[]> FindTrails((int Row, int Col) coordinate, int num, List<(int Row, int Col)> trail)
    {
        var trails = new List<(int Row, int Col)[]>();

        if (num > 9)
        {
            trails.Add([.. trail]);
            return trails;
        }

        var upRow = (Row: coordinate.Row - 1, coordinate.Col);
        if (upRow.Row >= 0
            && Map[upRow.Row][upRow.Col] == num)
        {
            var newTrail = new List<(int Row, int Col)>(trail) { upRow };
            trails.AddRange(FindTrails(upRow, num + 1, newTrail));
        }

        var downRow = (Row: coordinate.Row + 1, coordinate.Col);
        if (downRow.Row < Map.Count
            && Map[downRow.Row][downRow.Col] == num)
        {
            var newTrail = new List<(int Row, int Col)>(trail) { downRow };
            trails.AddRange(FindTrails(downRow, num + 1, newTrail));
        }

        var leftRow = (coordinate.Row, Col: coordinate.Col - 1);
        if (leftRow.Col >= 0
            && Map[leftRow.Row][leftRow.Col] == num)
        {
            var newTrail = new List<(int Row, int Col)>(trail) { leftRow };
            trails.AddRange(FindTrails(leftRow, num + 1, newTrail));
        }

        var rightRow = (coordinate.Row, Col: coordinate.Col + 1);
        if (rightRow.Col < Map[coordinate.Row].Count
            && Map[rightRow.Row][rightRow.Col] == num)
        {
            var newTrail = new List<(int Row, int Col)>(trail) { rightRow };
            trails.AddRange(FindTrails(rightRow, num + 1, newTrail));
        }

        return trails;
    }
}