namespace Problem8;

internal class Node
{
    public string Name { get; init; } = string.Empty;

    public string Left { get; init; } = string.Empty;

    public string Right { get; init; } = string.Empty;

    public override string ToString() => $"{Name} = ({Left}, {Right})";
}