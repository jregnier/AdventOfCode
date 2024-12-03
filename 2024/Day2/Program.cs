using AocUtilities;

using Day2;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var reportList = ReportList.Parse(inputfile);
    return reportList.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var reportList = ReportList.Parse(inputfile);
    return reportList.Solve2();
});