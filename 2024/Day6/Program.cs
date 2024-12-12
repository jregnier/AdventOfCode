using System.Text;

using AocUtilities;

using Day6;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var map = GuardLocatorMap.Parse(inputfile);
    return map.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var map = GuardLocatorMap.Parse(inputfile);
    return map.Solve2();
});