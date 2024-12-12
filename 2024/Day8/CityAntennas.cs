using System.Data;

namespace Day8;

internal record Antenna(int Row, int Col, char Frequency);

internal class CityAntennas
{
    public List<List<Antenna>> AntennaMap { get; set; } = [];

    public static CityAntennas Parse(string content)
    {
        var map = AocUtilities.InputReader.GetMapAsList(content);

        var result = new List<List<Antenna>>();

        for (int row = 0; row < map.Count; row++)
        {
            var rowList = new List<Antenna>();
            for (int col = 0; col < map[row].Count; col++)
            {
                var frequency = map[row][col];
                rowList.Add(new Antenna(row, col, frequency));
            }

            result.Add(rowList);
        }

        return new CityAntennas
        {
            AntennaMap = result
        };
    }

    public long Solve1()
    {
        var antennasGroups = AntennaMap
            .SelectMany(antennas => antennas)
            .Where(a => a.Frequency != '.')
            .GroupBy(x => x.Frequency)
            .ToDictionary(x => x, x => x.ToList());

        var antinodes = new HashSet<(int Row, int Col)>();

        foreach (var frequency in antennasGroups)
        {
            for (int i = 0; i < frequency.Value.Count; i++)
            {
                for (int j = i + 1; j < frequency.Value.Count; j++)
                {
                    var antenna1 = frequency.Value[i];
                    var antenna2 = frequency.Value[j];

                    var diffX = antenna1.Row - antenna2.Row;
                    var diffY = antenna1.Col - antenna2.Col;

                    var antinode1 = (Row: antenna1.Row + diffX, Col: antenna1.Col + diffY);
                    var antinode2 = (Row: antenna2.Row - diffX, Col: antenna2.Col - diffY);

                    if (antinode1.Row >= 0
                        && antinode1.Row < AntennaMap.Count
                        && antinode1.Col >= 0
                        && antinode1.Col < AntennaMap[antinode1.Row].Count
                        && !antinodes.Contains(antinode1))
                    {
                        antinodes.Add(antinode1);
                    }

                    if (antinode2.Row >= 0
                        && antinode2.Row < AntennaMap.Count
                        && antinode2.Col >= 0
                        && antinode2.Col < AntennaMap[antinode2.Row].Count
                        && !antinodes.Contains(antinode2))
                    {
                        antinodes.Add(antinode2);
                    }
                }

            }
        }

        return antinodes.Count;
    }

    public long Solve2()
    {
        var antennasGroups = AntennaMap
            .SelectMany(antennas => antennas)
            .Where(a => a.Frequency != '.')
            .GroupBy(x => x.Frequency)
            .ToDictionary(x => x, x => x.ToList());

        var antinodes = new HashSet<(int Row, int Col)>();

        foreach (var frequency in antennasGroups)
        {
            for (int i = 0; i < frequency.Value.Count; i++)
            {
                for (int j = i + 1; j < frequency.Value.Count; j++)
                {
                    var antenna1 = frequency.Value[i];
                    var antenna2 = frequency.Value[j];

                    var freqAntinodes = GetAntiNodesLine(antenna1, antenna2);
                    antinodes.UnionWith(freqAntinodes);
                }
            }
        }

        return antinodes.Count;
    }

    private HashSet<(int Row, int Col)> GetAntiNodesLine(Antenna antenna1, Antenna antenna2)
    {
        var diffX = antenna1.Row - antenna2.Row;
        var diffY = antenna1.Col - antenna2.Col;

        var freqAntinodes = new HashSet<(int Row, int Col)>();

        var antinode1 = (antenna1.Row, antenna1.Col);
        freqAntinodes.Add(antinode1);

        while (true)
        {
            antinode1 = (Row: antinode1.Row + diffX, Col: antinode1.Col + diffY);

            if (antinode1.Row >= 0
                && antinode1.Row < AntennaMap.Count
                && antinode1.Col >= 0
                && antinode1.Col < AntennaMap[antinode1.Row].Count
                && !freqAntinodes.Contains(antinode1))
            {
                freqAntinodes.Add(antinode1);
            }
            else
            {
                break;
            }
        }

        var antinode2 = (antenna2.Row, antenna2.Col);
        freqAntinodes.Add(antinode2);

        while (true)
        {
            antinode2 = (Row: antinode2.Row - diffX, Col: antinode2.Col - diffY);

            if (antinode2.Row >= 0
                && antinode2.Row < AntennaMap.Count
                && antinode2.Col >= 0
                && antinode2.Col < AntennaMap[antinode2.Row].Count
                && !freqAntinodes.Contains(antinode2))
            {
                freqAntinodes.Add(antinode2);
            }
            else
            {
                break;
            }
        }

        return freqAntinodes;
    }
}