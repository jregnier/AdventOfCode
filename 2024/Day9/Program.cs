using AocUtilities;

using Day9;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var diskMap = DiskMap.Parse(inputfile);
    return diskMap.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var diskMap = DiskMap.Parse(inputfile);
    return diskMap.Solve2();
});