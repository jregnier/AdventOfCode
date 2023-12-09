using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Problem5;

internal class Almanac
{
    public List<SeedRange> Seeds { get; set; } = [];

    public Map SeedToSoilMap { get; set; } = Map.Empty;

    public Map SoilToFertilizerMap { get; set; } = Map.Empty;

    public Map FertilizerToWaterMap { get; set; } = Map.Empty;

    public Map WaterToLightMap { get; set; } = Map.Empty;

    public Map LightToTemperatureMap { get; set; } = Map.Empty;

    public Map TemperatureToHumidityMap { get; set; } = Map.Empty;

    public Map HumidityToLocationMap { get; set; } = Map.Empty;

    public long GetLowestLocation()
    {
        long minLocation = 0;

        foreach (var seedRange in Seeds)
        {
            Console.Write($"Starting seed range: {seedRange.RangeStart} - {seedRange.RangeEnd}... ");

            var minRangeLocations = new ConcurrentBag<long>();
            Parallel.For(seedRange.RangeStart, seedRange.RangeEnd + 1, i =>
            {
                var soil = SeedToSoilMap.GetMap(i);
                var fert = SoilToFertilizerMap.GetMap(soil);
                var water = FertilizerToWaterMap.GetMap(fert);
                var light = WaterToLightMap.GetMap(water);
                var temp = LightToTemperatureMap.GetMap(light);
                var hum = TemperatureToHumidityMap.GetMap(temp);
                var location = HumidityToLocationMap.GetMap(hum);

                minRangeLocations.Add(location);
            });

            var minRangeLocation = minRangeLocations.Min();

            minLocation = minLocation == 0
                ? minRangeLocation
                : Math.Min(minLocation, minRangeLocation);

            Console.WriteLine("Done!");
        }

        return minLocation;
    }

    public static Almanac Parse(string input)
    {
        var result = new Almanac();

        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

        var seeds = inputLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Skip(1)
             .Select(uint.Parse)
             .ToList();

        for (int i = 0; i < seeds.Count; i += 2)
        {
            result.Seeds.Add(new SeedRange(seeds[i], seeds[i + 1]));
        }

        var mapLines = inputLines
            .Select((line, index) => new { line, index })
            .Skip(1)
            .Where(item => item.line.Contains(':'))
            .ToList();

        for (var j = 0; j < mapLines.Count; j++)
        {
            var name = mapLines[j].line.Trim();

            var endIndex = j == mapLines.Count - 1
                ? inputLines.Count - 1
                : mapLines[j + 1].index;

            var map = new Map();

            for (int i = mapLines[j].index + 1; i < endIndex; i++)
            {
                var items = inputLines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(uint.Parse)
                    .ToList();

                map.AddRange(items[0], items[1], items[2]);
            }

            SetMap(result, name, map);
        }

        return result;
    }

    private static void SetMap(Almanac almanac, string name, Map map)
    {
        switch (name)
        {
            case "seed-to-soil map:":
                almanac.SeedToSoilMap = map;
                break;
            case "soil-to-fertilizer map:":
                almanac.SoilToFertilizerMap = map;
                break;
            case "fertilizer-to-water map:":
                almanac.FertilizerToWaterMap = map;
                break;
            case "water-to-light map:":
                almanac.WaterToLightMap = map;
                break;
            case "light-to-temperature map:":
                almanac.LightToTemperatureMap = map;
                break;
            case "temperature-to-humidity map:":
                almanac.TemperatureToHumidityMap = map;
                break;
            case "humidity-to-location map:":
                almanac.HumidityToLocationMap = map;
                break;

        }
    }
}

public class SeedRange(long start, long range)
{
    public long RangeStart { get; } = start;

    public long RangeEnd { get; } = start + range - 1;

    public long Range {  get; } = range;
}