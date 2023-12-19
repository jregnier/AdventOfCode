using AocUtilities;

namespace Problem12;

internal class ConditionRecords
{
    internal readonly string[] _separator = [" ", ","];

    public long SolvePart1(string input)
    {
        long counter = 0;

        foreach (var springData in Parse(input))
        {
            var solver = new ArrangementSolver(springData);
            counter += solver.GetCount();
        }

        return counter;
    }

    public long SolvePart2(string input)
    {
        long counter = 0;

        foreach (var springData in Parse(input))
        {
            springData.Unfold();

            var solver = new ArrangementSolver(springData);
            counter += solver.GetCount();
        }

        return counter;
    }

    private List<SpringData> Parse(string input) =>
        InputReader.GetLines(input)
            .ConvertAll(line =>
            {
                var parts = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                var conditions = parts[0].Select(GetCondition).ToArray();
                var groups = parts.Skip(1).Select(int.Parse).ToArray();
                return new SpringData(parts[0], conditions, groups);
            });

    private ConditionType GetCondition(char key) => key switch
    {
        '.' => ConditionType.Operational,
        '#' => ConditionType.Broken,
        _ => ConditionType.Unknown,
    };
}