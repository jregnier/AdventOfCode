using AocUtilities;

namespace Problem14;

internal class RocksInput
{
    public Rock[][] RocksMap { get; init; } = [];

    public long SolvePart1()
    {
        TiltNorth();
        //PrintMap();

        long counter = 0;
        for (int row = 0; row < RocksMap.Length; row++)
        {
            for (int col = 0; col < RocksMap[row].Length; col++)
            {
                if (RocksMap[row][col].RockType == RockType.Rounded)
                {
                    counter += RocksMap.Length - row;
                }
            }
        }

        return counter;
    }

    public long SolvePart2()
    {
        return 1;
    }

    private void TiltNorth()
    {
        for (int row = 1; row < RocksMap.Length; row++)
        {
            for (int col = 0; col < RocksMap[row].Length; col++)
            {
                if (RocksMap[row][col].RockType == RockType.Rounded)
                {
                    for(int northRow = row - 1; northRow >= 0; northRow--)
                    {
                        if (RocksMap[northRow][col].RockType != RockType.Empty)
                        {
                            break;
                        }

                        if (northRow == 0
                            || RocksMap[northRow - 1][col].RockType != RockType.Empty)
                        {
                            RocksMap[northRow][col] = RocksMap[row][col];
                            RocksMap[row][col] = new Rock(RockType.Empty);
                        }
                    }
                }
            }
        }
    }

    private void PrintMap()
    {
        for (int row = 0; row < RocksMap.Length; row++)
        {
            for (int col = 0; col < RocksMap[row].Length; col++)
            {
                Console.Write(GetChar(RocksMap[row][col].RockType));
            }

            Console.WriteLine();
        }
    }

    public static RocksInput Parse(string inputFile)
    {
        var map = InputReader.GetMapAs2DArray(inputFile);

        var rocksMap = new Rock[map.Length][];

        for (int i = 0; i < map.Length; i++)
        {
            rocksMap[i] = new Rock[map[i].Length];

            for (int j = 0; j < map[i].Length; j++)
            {
                rocksMap[i][j] = new Rock(GetRockType(map[i][j]));
            }
        }

        return new RocksInput
        {
            RocksMap = rocksMap,
        };
    }

    private static RockType GetRockType(char c) => c switch
        {
            'O' => RockType.Rounded,
            '#' => RockType.Cubed,
            '.' => RockType.Empty,
            _ => throw new Exception("Unknown rock type"),
        };

    private static char GetChar(RockType rockType) => rockType switch
    {
            RockType.Rounded => 'O',
            RockType.Cubed => '#',
            RockType.Empty => '.',
            _ => throw new Exception("Unknown rock type"),
        };
}
