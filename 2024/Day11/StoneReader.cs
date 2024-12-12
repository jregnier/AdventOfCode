namespace Day11;

internal record Stone(string Value, long Number);

internal class StoneReader
{
    private Dictionary<string, long> _cache = new();

    public List<Stone> Stones { get; init; } = [];

    public static StoneReader Parse(string input)
    {
        var stones = AocUtilities.InputReader.GetText(input).Split(" ")
            .Select(x => new Stone(x, long.Parse(x)))
            .ToList();

        return new StoneReader
        {
            Stones = stones,
        };
    }

    public long GetStonesAmount(int blinkAmount)
    {
        var state = Stones
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => (long)x.Count());

        foreach (var blinkValue in Enumerable.Range(0, blinkAmount))
        {
            var newState = new Dictionary<Stone, long>();

            foreach (var stone in state)
            {
                if (CheckRule1(stone.Key))
                {
                    var newStone = Rule1();
                    AddOrUpdateState(newState, newStone, stone.Value);
                }
                else if (CheckRule2(stone.Key))
                {
                    var newStones = Rule2(stone.Key);
                    AddOrUpdateState(newState, newStones[0], stone.Value);
                    AddOrUpdateState(newState, newStones[1], stone.Value);
                }
                else
                {
                    var newStone = Rule3(stone.Key);
                    AddOrUpdateState(newState, newStone, stone.Value);
                }
            }

            state = newState;
        }

        return state.Sum(x => x.Value);
    }

    private static void AddOrUpdateState(Dictionary<Stone, long> state, Stone stone, long count)
    {
        if (state.ContainsKey(stone))
        {
            state[stone] += count;
        }
        else
        {
            state[stone] = count;
        }
    }

    public long Solve1()
    {
        const int BLINK_AMOUNT = 25;

        return GetStonesAmount(BLINK_AMOUNT);
    }

    public long Solve2()
    {
        const int BLINK_AMOUNT = 75;

        return GetStonesAmount(BLINK_AMOUNT);
    }

    private static bool CheckRule1(Stone stone) => stone.Number == 0;

    private static bool CheckRule2(Stone stone) => stone.Value.Length % 2 == 0;

    private static Stone Rule1() => new("1", 1);

    private static List<Stone> Rule2(Stone stone)
    {
        var firstHalf = long.Parse(stone.Value[..(stone.Value.Length / 2)]);
        var secondHalf = long.Parse(stone.Value[(stone.Value.Length / 2)..]);

        return [new Stone(firstHalf.ToString(), firstHalf), new Stone(secondHalf.ToString(), secondHalf)];
    }

    private static Stone Rule3(Stone stone)
    {
        var newNumber = stone.Number * 2024;
        return new Stone(newNumber.ToString(), newNumber);
    }
}