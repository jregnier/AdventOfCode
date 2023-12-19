using AocUtilities;

using Problem12;

var inputFile = InputReader.GetInputArg();

var conditionRecords = new ConditionRecords();

Runner.RunCodeWithTimer(1, () => conditionRecords.SolvePart1(inputFile));
Runner.RunCodeWithTimer(2, () => conditionRecords.SolvePart2(inputFile));