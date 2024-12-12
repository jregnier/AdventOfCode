using AocUtilities;

using Day8;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var cityArea = CityAntennas.Parse(inputfile);
    return cityArea.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var cityArea = CityAntennas.Parse(inputfile);
    return cityArea.Solve2();
});