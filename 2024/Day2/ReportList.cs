using AocUtilities;

namespace Day2;

internal class ReportList
{
    public List<Report> Reports { get; } = [];

    public long Solve1() => Reports.Count(x => x.IsSafe());

    public long Solve2() => Reports.Count(x => x.IsSafeWithProblemDamper());

    public static ReportList Parse(string content)
    {
        var reportList = new ReportList();
        foreach (var line in InputReader.GetLines(content))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var levels = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            reportList.Reports.Add(new Report {  Levels = levels });
        }

        return reportList;
    }
}