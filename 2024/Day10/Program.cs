using AocUtilities;

using Day10;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var areaMap = AreaMap.Parse(inputfile);
    return areaMap.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var areaMap = AreaMap.Parse(inputfile);
    return areaMap.Solve2();
});