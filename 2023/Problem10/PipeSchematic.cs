using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10;

enum PipeDirection
{
    NS,
    EW,
    NE,
    NW,
    SW,
    SE,
    Ground,
    Start,
}

internal class PipeSchematic
{
    private readonly static Dictionary<char, PipeDirection> _pipeMap = new()
    {
        { '|', PipeDirection.NS },
        { '-', PipeDirection.EW },
        { 'L', PipeDirection.NE },
        { 'J', PipeDirection.NW },
        { '7', PipeDirection.SW },
        { 'F', PipeDirection.SE },
        { '.', PipeDirection.Ground },
        { 'S', PipeDirection.Start },
    };

    public Dictionary<string, PipeDirection> PipeMatrix { get; init; } = [];

    private static string GetMatrixLookupString(int x, int y) => $"{x}_{y}";

    private static (int X, int Y) GetCoordinates(string lookupString)
    {
        var values = lookupString.Split("_", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        return (values[0], values[1]);
    }

    public string StartingPoint { get; init; } = string.Empty;

    public long FindNumberOfSteps()
    {
        var validPaths = GetValidPaths(StartingPoint);
        long counter = 1;

        foreach (var validPath in validPaths)
        {

        }

        return 1;
    }

    private List<(PipeDirection Direction, string Key)> GetValidPaths(string key)
    {
        var (X, Y) = GetCoordinates(key);

        var leftAndRight = Enumerable.Range(X - 1, 3)
            .Select(columnIndex => GetMatrixLookupString(columnIndex, Y))
            .Where(lookupString => lookupString != key && PipeMatrix.ContainsKey(lookupString))
            .Select(lookupString => (Direction: PipeMatrix[lookupString], Key: lookupString))
            .ToList();

        var left = leftAndRight[0];
        var right = leftAndRight[1];

        if (left.Direction != PipeDirection.EW
            && left.Direction != PipeDirection.NW
            && left.Direction != PipeDirection.SW)
        {
            leftAndRight.Remove(left);
        }

        if (right.Direction != PipeDirection.EW
            && right.Direction != PipeDirection.NE
            && right.Direction != PipeDirection.SE)
        {
            leftAndRight.Remove(right);
        }

        var aboveBelow = Enumerable.Range(Y - 1, 3)
            .Select(rowIndex => GetMatrixLookupString(Y, rowIndex))
            .Where(lookupString => lookupString != key && PipeMatrix.ContainsKey(lookupString))
            .Select(lookupString => (Direction: PipeMatrix[lookupString], Key: lookupString))
            .ToList();

        var above = aboveBelow[0];
        var below = aboveBelow[1];

        if (above.Direction != PipeDirection.NS
            && above.Direction != PipeDirection.NW
            && above.Direction != PipeDirection.NE)
        {
            aboveBelow.Remove(above);
        }

        if (below.Direction != PipeDirection.NS
            && below.Direction != PipeDirection.SW
            && below.Direction != PipeDirection.SE)
        {
            aboveBelow.Remove(below);
        }

        return leftAndRight.Union(aboveBelow)
            .Where(x => x.Direction != PipeDirection.Ground)
            .ToList();
    }

    public static PipeSchematic Parse(string input)
    {
        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

        var matrix = new Dictionary<string, PipeDirection>();

        var start = string.Empty;

        foreach (var line in inputLines.Select((x, i) => new { Line = x, Index = i }))
        {
            foreach (var column in line.Line
                .ToCharArray()
                .Select((x, i) => new { Direction = _pipeMap[x], Index = i }))
            {
                var lookupString = GetMatrixLookupString(column.Index, line.Index);

                if (column.Direction == PipeDirection.Start)
                {
                    start = lookupString;
                }

                matrix.Add(lookupString, column.Direction);
            }
        }

        return new PipeSchematic
        {
            PipeMatrix = matrix,
            StartingPoint = start,
        };
    }
}
