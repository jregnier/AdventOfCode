using AocUtilities;

using Problem11;

var arguments = Environment.GetCommandLineArgs();
Console.WriteLine($"Input file: {arguments[1]}");
Console.WriteLine();

Runner.RunCodeWithTimer(1, () =>
{
    var image = UniverseImage.Parse(arguments[1]);
    var value = image.SolvePart1();

    Console.WriteLine($"Result: {value}");
});

Runner.RunCodeWithTimer(2, () =>
{
    var image = UniverseImage.Parse(arguments[1]);
    var value = image.SolvePart2();

    Console.WriteLine($"Result: {value}");
});