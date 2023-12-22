using AocUtilities;

using Problem14;

var inputFile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var input = RocksInput.Parse(inputFile);
    return input.SolvePart1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var input = RocksInput.Parse(inputFile);
    return input.SolvePart2();
});