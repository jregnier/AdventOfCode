namespace Problem6;

internal class RaceTimes
{
    public List<(int Time, int Distance)> TimeDistances { get; } = [];

    public (long Time, long Distance) TimeDistance { get; set; }

    public int GetMarginOfErrorPart1()
    {
        var totalResult = 1;

        foreach (var (Time, Distance) in TimeDistances)
        {
            var tdResult = new List<int>();

            foreach (var buttonHoldTime in Enumerable.Range(0, Time))
            {
                var speed = buttonHoldTime;
                var timeLeft = Time - buttonHoldTime;
                var distance = speed * timeLeft;

                if (distance > Distance)
                {
                    tdResult.Add(distance);
                }
            }

            totalResult *= tdResult.Count;
        }

        return totalResult;
    }

    public long GetMarginOfErrorPart2()
    {
        long counter = 0;

        for (int buttonHoldTime = 0; buttonHoldTime <= TimeDistance.Time; buttonHoldTime++)
        {
            var speed = buttonHoldTime;
            var timeLeft = TimeDistance.Time - buttonHoldTime;
            var distance = speed * timeLeft;

            if (distance > TimeDistance.Distance)
            {
                counter++;
            }
        }

        return counter;
    }

    public static RaceTimes ParsePart1(string input)
    {
        var raceTimes = new RaceTimes();

        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();

        var timeLine = inputLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var disctanceLine = inputLines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < timeLine.Length; i++)
        {
            raceTimes.TimeDistances.Add((int.Parse(timeLine[i]), int.Parse(disctanceLine[i])));
        }

        return raceTimes;
    }

    public static RaceTimes ParsePart2(string input)
    {
        var raceTimes = new RaceTimes();

        var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();

        var timeLine = inputLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var disctanceLine = inputLines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var time = long.Parse(string.Concat(timeLine.Skip(1)));
        var distance = long.Parse(string.Concat(disctanceLine.Skip(1)));

        raceTimes.TimeDistance = (time, distance);

        return raceTimes;
    }
}