using AocUtilities;

using Problem15;

var inputFile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var input = new HashConverter();
    return input.SolvePart1(inputFile);
});

Runner.RunCodeWithTimer(2, () =>
{
    var input = new HashConverter();
    return input.SolvePart2(inputFile);
});