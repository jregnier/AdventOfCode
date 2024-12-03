namespace Day2;

internal class Report
{
    public List<long> Levels { get; init; } = [];

    public bool IsSafe()
    {
        var isSafe = true;

        var isIncreasing = Levels[0] < Levels[1];

        for (int i = 0; i < Levels.Count - 1; i++)
        {
            if (IsBadLevel(isIncreasing, Levels[i], Levels[i + 1]))
            {
                isSafe = false;
                break;
            }
        }

        return isSafe;
    }

    public bool IsSafeWithProblemDamper()
    {
        var isSafe = false;

        var badLevelFound = FindBadLevel(Levels);
        isSafe = !badLevelFound;

        if (badLevelFound)
        {
            for (int i = 0; i < Levels.Count; i++)
            {
                var levelsCopy = RemoveLevelAt(Levels, i);
                badLevelFound = FindBadLevel(levelsCopy);
                if (!badLevelFound)
                {
                    isSafe = true;
                    break;
                }
            }
        }

        return isSafe;
    }

    private static bool FindBadLevel(List<long> levels)
    {
        var isIncreasing = levels[0] < levels[1];

        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (IsBadLevel(isIncreasing, levels[i], levels[i + 1]))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsBadLevel(bool isIncreasing, long level1, long level2)
    {
        var diff = Math.Abs(level1 - level2);

        return (isIncreasing && level1 > level2)
            || (!isIncreasing && level1 < level2)
            || diff < 1
            || diff > 3;
    }

    private static List<long> RemoveLevelAt(List<long> levels, int i)
    {
        var levelsCopy = new List<long>(levels);
        levelsCopy.RemoveAt(i);
        return levelsCopy;
    }
}