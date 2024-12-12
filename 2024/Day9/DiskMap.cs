namespace Day9;

internal class DiskMap
{
    public List<BlockFileFragment> BlockFileFragments { get; set; } = [];

    public List<BlockFile> BlockFiles { get; set; } = [];

    public long Solve1()
    {
        var blocksCopy = new List<BlockFileFragment>(BlockFileFragments);

        for (int i = blocksCopy.Count - 1; i >= 0; i--)
        {
            var rightBlock = blocksCopy[i];
            if (rightBlock.IsSpace)
            {
                continue;
            }

            for (int j = 0; j < blocksCopy.Count; j++)
            {
                var leftBlock = blocksCopy[j];
                if (leftBlock.IsSpace)
                {
                    blocksCopy[j] = rightBlock;
                    blocksCopy[i] = BlockFileFragment.CreateSpace();
                    break;
                }
            }

            if (blocksCopy[blocksCopy.FindIndex(x => x.IsSpace)..].All(x => x.IsSpace))
            {
                break;
            }
        }

        return blocksCopy
            .Where(x => !x.IsSpace)
            .Select((file, i) => file.Id * i)
            .Sum();
    }

    public long Solve2()
    {
        var files = new List<BlockFile>(BlockFiles);

        for (int i = files.Count - 1; i >= 0; i--)
        {
            var file = files[i];
            if (file.IsSpace)
            {
                continue;
            }

            for (int j = 0; j < i; j++)
            {
                var possibleSpace = files[j];
                if (possibleSpace.IsSpace
                    && possibleSpace.Size >= file.Size)
                {
                    files[j] = file;
                    files[i] = BlockFile.CreateSpace(file.Size);

                    var diff = possibleSpace.Size - file.Size;
                    if (diff > 0)
                    {
                        files.Insert(j + 1, BlockFile.CreateSpace(diff));
                        i++;
                    }

                    break;
                }
            }
        }

        var fragments = files.SelectMany(x => x.Expand()).ToList();

        return fragments
            .Select((file, i) => file.IsSpace ? 0 : file.Id * i)
            .Sum();
    }

    private void Print(List<BlockFileFragment> blockFileFragments)
    {
        Console.WriteLine(string.Concat(blockFileFragments
            .Select(x =>
            {
                if (x.IsSpace)
                {
                    return ".";
                }
                else
                {
                    return x.Id.ToString();
                }
            })));
    }

    public static DiskMap Parse(string input)
    {
        var fragments = new List<BlockFileFragment>();
        var files = new List<BlockFile>();

        var isSpace = false;
        var fileId = 0;

        var text = AocUtilities.InputReader.GetText(input);
        foreach (var item in text)
        {
            var value = int.Parse(item.ToString());

            if (value != 0)
            {
                if (isSpace)
                {
                    Enumerable.Range(0, value)
                        .ToList()
                        .ForEach(_ => fragments.Add(BlockFileFragment.CreateSpace()));

                    files.Add(BlockFile.CreateSpace(value));
                }
                else
                {
                    Enumerable.Range(0, value)
                        .ToList()
                        .ForEach(_ => fragments.Add(BlockFileFragment.Create(fileId)));

                    files.Add(BlockFile.Create(fileId, value));

                    fileId++;
                }
            }

            isSpace = !isSpace;
        }

        return new DiskMap
        {
            BlockFileFragments = fragments,
            BlockFiles = files,
        };
    }
}
