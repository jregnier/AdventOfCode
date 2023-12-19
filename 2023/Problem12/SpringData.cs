namespace Problem12;

internal record SpringData
{
    public static List<ConditionType> OperationalTypes =
    [
        ConditionType.Operational,
        ConditionType.Unknown,
    ];

    public static List<ConditionType> BrokenTypes =
    [
        ConditionType.Broken,
        ConditionType.Unknown,
    ];

    public SpringData(string config, ConditionType[] conditions, int[] groups)
    {
        Config = config;
        Conditions = conditions;
        Groups = groups;
    }

    public string Config { get; }

    public ConditionType[] Conditions { get; private set; }

    public int[] Groups { get; private set; }

    public void Unfold()
    {
        var unfoldedConditions = new List<ConditionType>();
        var unfoldedGroup = new List<int>();

        foreach(var (cd, gs) in Enumerable.Range(0, 5)
            .Select(_ => (cd: Conditions, gs: Groups.ToList())))
        {
            if (unfoldedConditions.Count == 0)
            {
                unfoldedConditions.AddRange(cd);
            }
            else
            {
                unfoldedConditions.Add(ConditionType.Unknown);
                unfoldedConditions.AddRange(cd);
            }

            unfoldedGroup.AddRange(gs);
        }

        Conditions = [.. unfoldedConditions];
        Groups = [.. unfoldedGroup];
    }
}