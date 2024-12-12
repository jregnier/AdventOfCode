using AocUtilities;

using Day11;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var stoneReader = StoneReader.Parse(inputfile);
    return stoneReader.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var stoneReader = StoneReader.Parse(inputfile);
    return stoneReader.Solve2();
});