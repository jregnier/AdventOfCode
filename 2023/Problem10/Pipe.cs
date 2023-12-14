namespace Problem10;

internal class Pipe : IEquatable<Pipe>
{
    public bool CanUp => "S|LJ".Contains(Symbol);

    public bool CanDown => "S|7F".Contains(Symbol);

    public bool CanLeft => "S-J7".Contains(Symbol);

    public bool CanRight => "S-LF".Contains(Symbol);

    public int Distance { get; set; }

    public bool IsStart => Symbol == 'S';

    public Pipe? Parent { get; set; }

    public char Symbol { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public bool Equals(Pipe? other)
    {
        if (other == null)
        {
            return false;
        }

        return X == other.X
            && Y == other.Y
            && Symbol== other.Symbol;
    }

    public override bool Equals(object? obj) => Equals(obj as Pipe);

    public override int GetHashCode() => HashCode.Combine(X, Y, Symbol);

    public override string ToString() => $"{Symbol} {X} {Y}";
}

internal enum PipeDirection
{
    None,
    Up,
    Down,
    Left,
    Right,
}