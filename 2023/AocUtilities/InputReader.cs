using CommunityToolkit.Common;

namespace AocUtilities;

public static class InputReader
{
    public static List<string> GetLines(string inputFile)
        => File.ReadLines(inputFile).ToList();

    public static string GetText(string inputFile)
        => File.ReadAllText(inputFile);

    public static List<List<char>> GetMapAsList(string inputFile) =>
        GetLines(inputFile)
        .ConvertAll(line => line.ToCharArray().ToList());

    public static char[][] GetMapAs2DArray(string inputFile) => Get2DArray(GetText(inputFile));

    private static char[][] Get2DArray(string txt)
    {
        var lines = txt.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var matrix = new char[lines.Length][];

        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            var line = lines[lineIndex].ToCharArray();
            matrix[lineIndex] = [.. line];
        }

        return matrix;
    }

    public static (string[] rows, string[] columns) GetRowsAndColumns(string text)
    {
        var map = Get2DArray(text);
        var rows = map.Select(x => new string(x)).ToArray();
        var columns = Enumerable.Range(0, map[0].Length)
            .Select(x => new string(map.GetColumn(x).ToArray()))
            .ToArray();

        return (rows, columns);
    }

    public static string GetInputArg()
    {
        var arguments = Environment.GetCommandLineArgs();
        Console.WriteLine($"Input file: {arguments[1]}");
        Console.WriteLine();

        return arguments[1];
    }
}