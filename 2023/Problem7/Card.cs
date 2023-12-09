namespace Problem7;

internal class Card
{
    public char Value { get; init; }

    public int Power { get; init; }

    public override string ToString() => Value.ToString();
}