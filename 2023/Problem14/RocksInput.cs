using AocUtilities;

namespace Problem14;

internal class RocksInput(char[][] map)
{
    public char[][] Map { get; init; } = map;

    public long SolvePart1()
    {
        TiltNorth(Map);

        return GetNorthLoad(Map);
    }

    public long SolvePart2()
    {
        long result = 0;
        var gridCache = new HashSet<int>();
        var loads = new List<(int HashCode, long Load)>();

        var map = SpinCycle(Map);

        for (int i = 1; i <= 100000; i++)
        {
            var hashCode = GetGridHashCode(map);
            if (gridCache.Contains(hashCode))
            {
                var loadIndex = loads.FindIndex(f => f.HashCode == hashCode) + 1;
                var loop = i - loadIndex;
                var index = loadIndex + ((1000000000 - loadIndex - 1) % loop);
                result = loads[index].Load;
                break;
            }

            var load = GetNorthLoad(map);
            gridCache.Add(hashCode);
            loads.Add((hashCode, load));
            map = SpinCycle(map);
        }

        return result;
    }

    private static int GetGridHashCode(char[][] map)
    {
        var hash = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                hash = HashCode.Combine(hash, map[i][j]);
            }
        }

        return hash;
    }

    private static char[][] SpinCycle(char[][] map)
    {
        TiltNorth(map);

        var newMap = Rotate90(map);
        TiltNorth(newMap);

        newMap = Rotate90(newMap);
        TiltNorth(newMap);

        newMap = Rotate90(newMap);
        TiltNorth(newMap);

        return Rotate90(newMap);
    }

    private static void PrintMap(char[][] map)
    {
        for (int row = 0; row < map.Length; row++)
        {
            for (int col = 0; col < map[row].Length; col++)
            {
                Console.Write(map[row][col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static long GetNorthLoad(char[][] map)
    {
        long counter = 0;
        for (int row = 0; row < map.Length; row++)
        {
            for (int col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == 'O')
                {
                    counter += map.Length - row;
                }
            }
        }

        return counter;
    }

    private static void TiltNorth(char[][] chars)
    {
        for (int row = 1; row < chars.Length; row++)
        {
            for (int col = 0; col < chars[row].Length; col++)
            {
                if (chars[row][col] == 'O')
                {
                    for (int northRow = row - 1; northRow >= 0; northRow--)
                    {
                        if (chars[northRow][col] != '.')
                        {
                            break;
                        }

                        if (northRow == 0
                            || chars[northRow - 1][col] != '.')
                        {
                            chars[northRow][col] = chars[row][col];
                            chars[row][col] = '.';
                        }
                    }
                }
            }
        }
    }

    private static char[][] Rotate90(char[][] map)
    {
        var newMap = new char[map[0].Length][];

        for (int row = 0; row < map[0].Length; row++)
        {
            newMap[row] = new char[map[0].Length];
            for (int col = 0; col < map.Length; col++)
            {
                newMap[row][col] = map[map.Length - col -1][row];
            }
        }

        return newMap;
    }

    public static RocksInput Parse(string inputFile)
    {
        var map = InputReader.GetMapAs2DArray(inputFile);
        return new RocksInput(map);
    }
}
