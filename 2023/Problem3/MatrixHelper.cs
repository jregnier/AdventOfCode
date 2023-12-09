using System.Drawing;

namespace Problem3;

internal static class MatrixHelper
{
    public static char[,] GetMatrix(string schematic)
    {
        var schematicLines = schematic.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        var linesAsChars = schematicLines.Select(x => x.ToCharArray()).ToArray();

        var matrix = new char[linesAsChars.Length, linesAsChars.Max(x => x.Length)];

        for (int lineIndex = 0; lineIndex < schematicLines.Count; lineIndex++)
        {
            var line = schematicLines[lineIndex].ToCharArray();
            for (int columnIndex = 0; columnIndex < line.Length; columnIndex++)
            {
                matrix[lineIndex, columnIndex] = line[columnIndex];
            }
        }

        return matrix;
    }

    public static char[] GetNearbyValues(char[,] matrix, int i, int j)
    {
        var result = new List<char>();

        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x == i && y == j)
                {
                    continue;
                }

                if (x > 0 && x < matrix.GetLength(0)
                    && y > 0 && y < matrix.GetLength(1))
                {
                    result.Add(matrix[x, y]);
                }

            }
        }

        return [.. result];
    }

    public static bool IsAdjacentToSymbol(char[] items) =>
        !items.All(x => x == '.' || char.IsNumber(x));

    public static List<Point> GetAdjacentStarPoint(char[,] matrix, int i, int j)
    {
        var result = new List<Point>();

        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x == i && y == j)
                {
                    continue;
                }

                if (x > 0 && x < matrix.GetLength(0)
                    && y > 0 && y < matrix.GetLength(1)
                    && matrix[x, y] == '*')
                {
                    result.Add(new Point(x, y));
                }

            }
        }

        return result;
    }
}

