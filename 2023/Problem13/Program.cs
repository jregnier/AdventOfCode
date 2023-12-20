using AocUtilities;
using Problem13;

var inputFile = InputReader.GetInputArg();

var notes = PatternNotes.Parse(inputFile);

Runner.RunCodeWithTimer(1, () => notes.SolvePart1());
Runner.RunCodeWithTimer(2, () => notes.SolvePart2());