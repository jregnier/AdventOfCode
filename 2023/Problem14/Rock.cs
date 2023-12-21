namespace Problem14;

public enum RockType
{
    Rounded,
    Cubed,
    Empty,
}

internal record Rock(RockType RockType)
{
    public override string ToString() => RockType.ToString();
}
