namespace Day6;

internal class MapLocation(int row, int col, char value)
{
    public const char OBSTRUCTION_LOCATION = '#';

    public int Col { get; } = col;

    public bool IsObstruction => Value == OBSTRUCTION_LOCATION;

    public int Row { get; } = row;

    public char Value { get; set; } = value;

    public override string ToString() => $"{Row}x{Col} {Value}";
}