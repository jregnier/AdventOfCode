using AocUtilities;

using Problem14;

var inputFile = InputReader.GetInputArg();

var input = RocksInput.Parse(inputFile);

Runner.RunCodeWithTimer(1, () => input.SolvePart1());
Runner.RunCodeWithTimer(2, () => input.SolvePart2());