namespace Day5;

internal class Rule
{
    public const string RULE_PAGE_SEPARATOR = "|";

    public Rule(string rule)
    {
        RuleString = rule;

        var split = rule.Split(RULE_PAGE_SEPARATOR);
        X = int.Parse(split[0]);
        Y = int.Parse(split[1]);
    }

    public string RuleString { get; }

    public int X { get; }

    public int Y { get; }

    public static string CreateRuleString(int x, int y) => $"{x}|{y}";
}

internal class Rules(List<Rule> rulesList)
{
    private readonly Dictionary<string, Rule> _ruleLookup = rulesList.ToDictionary(x => x.RuleString, x => x);

    public List<Rule> RulesList { get; } = rulesList;

    public bool Exists(int x, int y) => _ruleLookup.ContainsKey(Rule.CreateRuleString(x, y));
}