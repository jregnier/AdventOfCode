using System.Text;

using AocUtilities;

using Day5;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var safetyManual = SafetyManual.Parse(inputfile);
    return safetyManual.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var safetyManual = SafetyManual.Parse(inputfile);
    return safetyManual.Solve2();
});