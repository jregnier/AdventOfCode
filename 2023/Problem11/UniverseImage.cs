using System.Drawing;

using AocUtilities;

using MathNet.Numerics;

namespace Problem11;

internal class UniverseImage
{
    public List<List<char>> Map { get; init; } = [];

    public static UniverseImage Parse(string inputFile)
    {
        var map = InputReader.GetMapAsList(inputFile);

        return new UniverseImage
        {
            Map = map,
        };
    }

    public long SolvePart1()
    {
        ExpandGalaxy(1);
        var galaxies = GetGalaxies(Map);

        double sum = 0;

        for (int i = 0; i < galaxies.Count; i++)
        {
            for (int j = i + 1; j < galaxies.Count; j++)
            {
                var from = galaxies[i];
                var to = galaxies[j];

                var fromCoord = new double[] { from.X, from.Y };
                var toCoord = new double[] { to.X, to.Y };

                var distance = Distance.Manhattan(fromCoord, toCoord);
                sum += distance;
            }
        }

        return (long)sum;
    }

    public long SolvePart2()
    {
        const double EXPAND_AMOUNT = 1000000;

        var (emptyRows, emptyColumns) = GetEmptyRowsAndColumns();
        var galaxies = GetGalaxies(Map);

        double sum = 0;

        for (int i = 0; i < galaxies.Count; i++)
        {
            for (int j = i + 1; j < galaxies.Count; j++)
            {
                var from = galaxies[i];
                var to = galaxies[j];

                var fromCoord = new double[] { from.X, from.Y };
                var toCoord = new double[] { to.X, to.Y };

                //Console.Write("Original ");
                //PrintDistance(fromCoord, toCoord);

                fromCoord[0] = GetExpansionValue(emptyColumns, fromCoord[0], EXPAND_AMOUNT);
                toCoord[0] = GetExpansionValue(emptyColumns, toCoord[0], EXPAND_AMOUNT);
                fromCoord[1] = GetExpansionValue(emptyRows, fromCoord[1], EXPAND_AMOUNT);
                toCoord[1] = GetExpansionValue(emptyRows, toCoord[1], EXPAND_AMOUNT);

                var distance = Distance.Manhattan(fromCoord, toCoord);

                //Console.Write("Expanded ");
                //PrintDistance(fromCoord, toCoord, distance);

                sum += distance;
            }
        }

        return (long)sum;
    }

    private static double GetExpansionValue(List<long> emptyList, double coordinate, double expandAmount)
    {
        var count = emptyList.Count(x => x < coordinate);
        return (coordinate - count) + (count * expandAmount);
    }

    private static List<Point> GetGalaxies(List<List<char>> map)
    {
        var galaxies = new List<Point>();
        for (int row = 0; row < map.Count; row++)
        {
            for (int col = 0; col < map[row].Count; col++)
            {
                if (map[row][col] == '#')
                {
                    galaxies.Add(new Point(col, row));
                }
            }
        }

        return galaxies;
    }

    private static void PrintDistance(double[] from, double[] to, double? distance = null)
    {
        Console.Write($"From: ({from[0]}, {from[1]}) To: ({to[0]}, {to[1]})");

        if (distance != null)
        {
            Console.Write($" Distance: {distance}");
        }

        Console.WriteLine();
    }

    private static void PrintMap(List<List<char>> map)
    {
        for (int row = 0; row < map.Count; row++)
        {
            for (int col = 0; col < map[row].Count; col++)
            {
                Console.Write(map[row][col]);
            }

            Console.WriteLine();
        }
    }

    private void ExpandGalaxy(int number)
    {
        // Expand columns
        for (int col = Map[0].Count - 1; col >= 0; col--)
        {
            var colItems = new List<char>();

            for (int row = 0; row < Map.Count; row++)
            {
                colItems.Add(Map[row][col]);
            }

            if (colItems.All(x => x == '.'))
            {
                for (int row = 0; row < Map.Count; row++)
                {
                    Enumerable.Range(0, number)
                    .ToList()
                    .ForEach(_ => Map[row].Insert(col + 1, '.'));
                }
            }
        }

        // Expand rows
        for (int row = Map.Count - 1; row >= 0; row--)
        {
            var rowItems = new List<char>();

            for (int col = 0; col < Map[row].Count; col++)
            {
                rowItems.Add(Map[row][col]);
            }

            if (rowItems.All(x => x == '.'))
            {
                Enumerable.Range(0, number)
                .ToList()
                .ForEach(x => Map.Insert(row + 1, rowItems));
            }
        }
    }

    private (List<long> Rows, List<long> Columns) GetEmptyRowsAndColumns()
    {
        var rows = new List<long>();
        var columns = new List<long>();

        for (int row = 0; row <= Map.Count - 1; row++)
        {
            var rowItems = new List<char>();

            for (int col = 0; col < Map[row].Count; col++)
            {
                rowItems.Add(Map[row][col]);
            }

            if (rowItems.All(x => x == '.'))
            {
                rows.Add(row);
            }
        }

        // Expand columns
        for (int col = Map[0].Count - 1; col >= 0; col--)
        {
            var colItems = new List<char>();

            for (int row = 0; row < Map.Count; row++)
            {
                colItems.Add(Map[row][col]);
            }

            if (colItems.All(x => x == '.'))
            {
                columns.Add(col);
            }
        }

        return (rows, columns);
    }
}