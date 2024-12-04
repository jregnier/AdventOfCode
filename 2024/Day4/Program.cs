using AocUtilities;

using Day4;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () => WordSearch.Solve1(inputfile));

Runner.RunCodeWithTimer(2, () => WordSearch.Solve2(inputfile));