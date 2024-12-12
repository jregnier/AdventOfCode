using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5;

internal class SafetyManual
{
    public Rules PageOrderingRules { get; set; } = new Rules([]);

    public List<Update> Updates { get; set; } = [];

    public static SafetyManual Parse(string content)
    {
        var lines = AocUtilities.InputReader.GetLines(content);

        var sectionSplitLine = lines.IndexOf(string.Empty);

        var pageOrderingRules = lines
            .GetRange(0, sectionSplitLine)
            .ConvertAll(x => new Rule(x));

        var updates = lines.GetRange(sectionSplitLine + 1, lines.Count - sectionSplitLine - 1)
            .ConvertAll(x =>
            {
                var split = x.Split(',').ToList();
                return new Update
                {
                    Pages = split.ConvertAll(int.Parse)
                };
            });

        return new SafetyManual
        {
            PageOrderingRules = new Rules(pageOrderingRules),
            Updates = updates,
        };
    }

    private void Analyze()
    {
        foreach (var update in Updates)
        {
            var isValid = true;
            for (var i = 0; i < update.Pages.Count; i++)
            {
                for (var j = 0; j < update.Pages.Count; j++)
                {
                    if (i < j
                        && !PageOrderingRules.Exists(
                            update.Pages[i],
                            update.Pages[j]))
                    {
                        isValid = false;
                    }

                    if (i > j
                        && !PageOrderingRules.Exists(
                            update.Pages[j],
                            update.Pages[i]))
                    {
                        isValid = false;
                    }
                }

                update.IsValid = isValid;
            }
        }
    }

    public long Solve1()
    {
        Analyze();
        return Updates.Where(x => x.IsValid).Sum(x => x.GetMiddlePage());
    }

    public long Solve2()
    {
        Analyze();

        var invalideUpdates = Updates.Where(x => !x.IsValid).ToList();

        var newUpdates = new List<Update>();
        foreach (var update in invalideUpdates)
        {
            var pages = update.Pages.ConvertAll(x => new Page(x, PageOrderingRules));
            var newUpdate = new Update
            {
                Pages = pages.Order().Select(x => x.PageNumber).ToList()
            };

            newUpdates.Add(newUpdate);
        }

        return newUpdates.Sum(x => x.GetMiddlePage());
    }
}