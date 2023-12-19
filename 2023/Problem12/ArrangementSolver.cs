namespace Problem12;

internal class ArrangementSolver(SpringData springData)
{
    private readonly Dictionary<(int, int), long> _cache = [];

    public SpringData SpringData { get; } = springData;

    public long GetCount() => CountArrangements(0, 0);

    private long CountArrangements(int conditionTypeIndex, int groupIndex)
    {
        var key = (conditionTypeIndex, groupIndex);

        if (_cache.TryGetValue(key, out long value))
        {
            return value;
        }

        if (conditionTypeIndex >= SpringData.Conditions.Length)
        {
            return groupIndex == SpringData.Groups.Length ? 1 : 0;
        }

        if (groupIndex == SpringData.Groups.Length)
        {
            return SpringData.Conditions[conditionTypeIndex..].Contains(ConditionType.Broken) ? 0 : 1;
        }

        long result = 0;

        var conditionType = SpringData.Conditions[conditionTypeIndex];
        var group = SpringData.Groups[groupIndex];

        if (conditionType == ConditionType.Operational || conditionType == ConditionType.Unknown)
        {
            result += CountArrangements(conditionTypeIndex + 1, groupIndex);
        }

        if (conditionType == ConditionType.Broken || conditionType == ConditionType.Unknown)
        {
            if (group <= SpringData.Conditions.Length - conditionTypeIndex
                && !SpringData.Conditions[conditionTypeIndex..(conditionTypeIndex + group)].Contains(ConditionType.Operational)
                && (group == SpringData.Conditions.Length - conditionTypeIndex
                || SpringData.Conditions[conditionTypeIndex + group] != ConditionType.Broken))
            {
                var nextConditionIndex = conditionTypeIndex + group + 1;
                var nextGroupIndex = groupIndex + 1;

                result += CountArrangements(nextConditionIndex, nextGroupIndex);
            }
            else
            {
                result += 0;
            }
        }

        _cache.Add(key, result);

        return result;
    }
}