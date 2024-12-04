using System.Data;

namespace Day4;

internal static class WordSearch
{
    private const string XMAS = "XMAS";
    private const string MAS = "MAS";

    public static bool IsMASAsX(List<List<char>> map, int rowIndex, int colIndex)
    {
        var cross1 = false;
        var cross2 = false;

        if (rowIndex - 1 >= 0
            && colIndex - 1 >= 0
            && rowIndex + 1 < map.Count
            && colIndex + 1 < map[rowIndex + 1].Count)
        {
            var word = $"{map[rowIndex - 1][colIndex - 1]}{map[rowIndex][colIndex]}{map[rowIndex + 1][colIndex + 1]}";
            if (word == MAS
                || ReverseString(word) == MAS)
            {
                cross1 = true;
            }
        }

        if (rowIndex + 1 < map.Count
            && colIndex - 1 >= 0
            && rowIndex - 1 >= 0
            && colIndex + 1 < map[rowIndex - 1].Count)
        {
            var word = $"{map[rowIndex + 1][colIndex - 1]}{map[rowIndex][colIndex]}{map[rowIndex - 1][colIndex + 1]}";
            if (word == MAS
                || ReverseString(word) == MAS)
            {
                cross2 = true;
            }
        }

        return cross1 && cross2;
    }

    private static string ReverseString(string value)
    {
        var charArray = value.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static int GetXmasCount(List<List<char>> map, int rowIndex, int colIndex)
    {
        var up = "X";
        var down = "X";
        var left = "X";
        var right = "X";
        var upLeft = "X";
        var downLeft = "X";
        var upRight = "X";
        var downRight = "X";

        for (int letterIndex = 1; letterIndex < XMAS.Length; letterIndex++)
        {
            if (XMAS.StartsWith(up)
                && rowIndex - letterIndex >= 0)
            {
                up += map[rowIndex - letterIndex][colIndex].ToString();
            }

            if (XMAS.StartsWith(down)
                && rowIndex + letterIndex < map.Count)
            {
                down += map[rowIndex + letterIndex][colIndex].ToString();
            }

            if (XMAS.StartsWith(left)
                && colIndex - letterIndex >= 0)
            {
                left += map[rowIndex][colIndex - letterIndex].ToString();
            }

            if (XMAS.StartsWith(right)
                && colIndex + letterIndex < map[rowIndex].Count)
            {
                right += map[rowIndex][colIndex + letterIndex].ToString();
            }

            if (XMAS.StartsWith(upLeft)
                && rowIndex - letterIndex >= 0
                && colIndex - letterIndex >= 0)
            {
                upLeft += map[rowIndex - letterIndex][colIndex - letterIndex].ToString();
            }

            if (XMAS.StartsWith(upRight)
                && rowIndex - letterIndex >= 0
                && colIndex + letterIndex < map[rowIndex].Count)
            {
                upRight += map[rowIndex - letterIndex][colIndex + letterIndex].ToString();
            }

            if (XMAS.StartsWith(downLeft)
                && rowIndex + letterIndex < map.Count
                && colIndex - letterIndex >= 0)
            {
                downLeft += map[rowIndex + letterIndex][colIndex - letterIndex].ToString();
            }

            if (XMAS.StartsWith(downRight)
                && rowIndex + letterIndex < map.Count
                && colIndex + letterIndex < map[rowIndex].Count)
            {
                downRight += map[rowIndex + letterIndex][colIndex + letterIndex].ToString();
            }
        }

        return new[]
        {
            up,
            down,
            left,
            right,
            upLeft,
            upRight,
            downLeft,
            downRight,
        }.Count(x => x == XMAS);
    }

    public static long Solve1(string content)
    {
        var wordSearchMap = AocUtilities.InputReader.GetMapAsList(content);

        var result = 0;

        for (int row = 0; row < wordSearchMap.Count; row++)
        {
            for (int col = 0; col < wordSearchMap[row].Count; col++)
            {
                if (wordSearchMap[row][col] == XMAS[0])
                {
                    result += GetXmasCount(wordSearchMap, row, col);
                }
            }
        }

        return result;
    }

    public static long Solve2(string content)
    {
        var wordSearchMap = AocUtilities.InputReader.GetMapAsList(content);

        var result = 0;

        for (int row = 0; row < wordSearchMap.Count; row++)
        {
            for (int col = 0; col < wordSearchMap[row].Count; col++)
            {
                if (wordSearchMap[row][col] == 'A')
                {
                    if (IsMASAsX(wordSearchMap, row, col))
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }
}