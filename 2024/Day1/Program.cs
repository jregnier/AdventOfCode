using AocUtilities;
using Day1;

var inputfile = InputReader.GetInputArg();

Runner.RunCodeWithTimer(1, () =>
{
    var comparer = ListComparer.Parse(inputfile);
    return comparer.Solve1();
});

Runner.RunCodeWithTimer(2, () =>
{
    var comparer = ListComparer.Parse(inputfile);
    return comparer.Solve2();
});