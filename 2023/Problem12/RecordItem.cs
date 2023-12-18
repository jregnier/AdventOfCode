namespace Problem12;

internal record RecordItem
{
    public RecordItem(string config, List<int> groupSequence)
    {
        Config = config;
        GroupSequence = groupSequence;
    }

    public string Config { get; private set; }

    public List<int> GroupSequence { get; private set; }

    public void Unfold()
    {
        var configs = Enumerable.Range(0, 5).Select(_ => (cfg:Config, gs: GroupSequence.ToList())).ToList();
        Config = string.Join("?", configs.Select(x => x.cfg));

        GroupSequence.Clear();
        configs.ForEach(x => GroupSequence.AddRange(x.gs));
    }
}