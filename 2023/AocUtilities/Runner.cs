namespace AocUtilities;

public static class Runner
{
    public static void RunCodeWithTimer(int part, Action action)
    {
        Console.WriteLine($"Part {part}!!");
        var startTime = DateTime.Now;

        action();

        Console.WriteLine($"Time: {DateTime.Now - startTime}");
        Console.WriteLine();
    }

    public static async Task RunCodeWithTimer(int part, Func<Task> action)
    {
        Console.WriteLine($"Part {part}!!");
        var startTime = DateTime.Now;

        await action();

        Console.WriteLine($"Time: {DateTime.Now - startTime}");
        Console.WriteLine();
    }
}