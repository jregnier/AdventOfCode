namespace Problem12;

internal class Key(ConditionType[] config, int[] groups) : IEquatable<Key>
{
    public string AsString { get; } = string.Empty;

    public ConditionType[] Config { get; } = config;

    public int[] Groups { get; } = groups;

    public override bool Equals(object? obj) => obj is Key key && Equals(key);

    public bool Equals(Key? other) =>
        other != null
        && Config.SequenceEqual(other.Config)
        && Groups.SequenceEqual(other.Groups);

    public override int GetHashCode() => HashCode.Combine(Config, Groups);
}