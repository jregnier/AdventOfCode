using AocUtilities;

using Day7;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var calbrationEquations = CalibrationEquations.Parse(inputfile);
    return calbrationEquations.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var calbrationEquations = CalibrationEquations.Parse(inputfile);
    return calbrationEquations.Solve2();
});