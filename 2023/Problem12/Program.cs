using AocUtilities;

using Problem12;

var arguments = Environment.GetCommandLineArgs();
Console.WriteLine($"Input file: {arguments[1]}");
Console.WriteLine();

var conditionRecords = new ConditionRecords();

Runner.RunCodeWithTimer(1, () => Console.WriteLine($"Result: {conditionRecords.SolvePart1(arguments[1])}"));
Runner.RunCodeWithTimer(2, () => Console.WriteLine($"Result: {conditionRecords.SolvePart2(arguments[1])}"));