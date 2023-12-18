using AocUtilities;

namespace Problem12;

internal class ConditionRecords
{
    internal readonly string[] _separator = [" ", ","];

    public long SolvePart1(string input)
    {
        long counter = 0;

        foreach (var recordItem in Parse(input))
        {
            counter += CountArrangements(recordItem.Config, recordItem.GroupSequence);
        }

        return counter;
    }

    public long SolvePart2(string input)
    {
        long counter = 0;

        Parallel.ForEach(Parse(input), recordItem =>
        {
            recordItem.Unfold();
            counter += CountArrangements(recordItem.Config, recordItem.GroupSequence);
        });

        return counter;
    }

    private static long CountArrangements(string config, List<int> groupSequences)
    {
        if (string.IsNullOrEmpty(config))
        {
            return groupSequences.Count == 0 ? 1 : 0;
        }

        if (groupSequences.Count == 0)
        {
            return config.Contains('#') ? 0 : 1;
        }

        long result = 0;

        if (".?".Contains(config[0]))
        {
            result += CountArrangements(config[1..], groupSequences);
        }

        if ("#?".Contains(config[0]))
        {
            if (groupSequences[0] <= config.Length
                && !config[..groupSequences[0]].Contains('.')
                && (groupSequences[0] == config.Length || config[groupSequences[0]] != '#'))
            {
                var toRemoveNum = groupSequences[0] + 1;
                var updatedConfig = toRemoveNum > config.Length
                    ? string.Empty
                    : config[toRemoveNum..];
                result += CountArrangements(updatedConfig, groupSequences[1..]);
            }
            else
            {
                result += 0;
            }
        }

        return result;
    }

    private List<RecordItem> Parse(string input) =>
        InputReader.GetLines(input)
            .ConvertAll(line =>
            {
                var parts = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                var groupSequence = parts.Skip(1).Select(int.Parse).ToList();
                return new RecordItem(parts[0], groupSequence);
            });
}