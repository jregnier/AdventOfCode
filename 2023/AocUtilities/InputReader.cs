namespace AocUtilities;

public static class InputReader
{
    public static List<string> GetLines(string inputFile)
        => File.ReadLines(inputFile).ToList();

    public static string GetText(string inputFile)
        => File.ReadAllText(inputFile);        

    public static List<List<char>> GetMapAsChar(string inputFile)
        => GetLines(inputFile).Select(line => line.ToCharArray().ToList()).ToList();             
}