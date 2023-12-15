using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Problem11;

internal class UniverseImage
{
    public List<Point> Galaxies { get; init; } = [];

    public List<List<char>> Map { get; init; } = [];

    public long SolvePart1()
    {
        double sum = 0;

        for (int i = 0; i < Galaxies.Count; i++)
        {
            for (int j = i + 1; j < Galaxies.Count; j++)
            {
                var from = Galaxies[i];
                var to = Galaxies[j];

                sum += Distance.Manhattan(new double[] { from.X, from.Y }, [to.X, to.Y]);
            }
        }

        return (long)sum;
    }

    public static UniverseImage Parse(string input)
    {
        var map = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.ToCharArray().ToList())
            .ToList();

        // Expand rows
        for (int row = map.Count - 1; row >= 0; row--)
        {
            var rowItems = new List<char>();

            for (int col = 0; col < map[row].Count; col++)
            {
                rowItems.Add(map[row][col]);
            }

            if (rowItems.All(x => x == '.'))
            {
                map.Insert(row + 1, rowItems);
            }
        }

        // Expand columns
        for (int col = map[0].Count - 1; col >= 0; col--)
        {
            var colItems = new List<char>();

            for (int row = 0; row < map.Count; row++)
            {
                colItems.Add(map[row][col]);
            }

            if (colItems.All(x => x == '.'))
            {
                for (int row = 0; row < map.Count; row++)
                {
                    map[row].Insert(col + 1, '.');
                }
            }
        }

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

        return new UniverseImage
        {
            Map = map,
            Galaxies = galaxies,
        };
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
}