namespace Day9;

internal record BlockFileFragment(long Id, bool IsSpace)
{
    public static BlockFileFragment Create(long id) => new(id, false);
    public static BlockFileFragment CreateSpace() => new(-1, true);
}

internal record BlockFile(long Id, int Size, bool IsSpace)
{
    public static BlockFile Create(long id, int size) => new(id, size, false);
    public static BlockFile CreateSpace(int size) => new(-1, size, true);

    public List<BlockFileFragment> Expand()
    {
        return Enumerable.Range(0, Size)
            .Select(x => IsSpace
                ? BlockFileFragment.CreateSpace()
                : BlockFileFragment.Create(Id))
            .ToList();
    }
}
