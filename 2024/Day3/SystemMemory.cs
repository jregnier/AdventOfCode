namespace Day3;

internal static class SystemMemory
{
    public static long Solve1(string content)
    {
        const string MUL = "mul(";

        var corruptedMemory = AocUtilities.InputReader.GetText(content);

        long result = 0;

        foreach (var mul in corruptedMemory
            .Split(MUL, StringSplitOptions.RemoveEmptyEntries))
        {
            var rightIndex = mul.IndexOf(')');
            if (rightIndex == -1)
            {
                continue;
            }

            var insideBackets = mul[..rightIndex];

            var values = insideBackets.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (values.Length == 2
                && !values[0].Any(char.IsWhiteSpace)
                && !values[1].Any(char.IsWhiteSpace)
                && int.TryParse(values[0], out var value1)
                && int.TryParse(values[1], out var value2))
            {
                result += value1 * value2;
            }
        }

        return result;
    }

    public static long Solve2(string content)
    {
        const string MUL = "mul(";
        const string DO = "do()";
        const string DONT = "don't()";

        var corruptedMemory = AocUtilities.InputReader.GetText(content);

        long result = 0;
        bool doFlag = true;

        foreach (var mul in corruptedMemory
            .Split(MUL, StringSplitOptions.RemoveEmptyEntries))
        {
            if (doFlag)
            {
                var rightIndex = mul.IndexOf(')');
                if (rightIndex == -1)
                {
                    continue;
                }

                var insideBackets = mul[..rightIndex];

                var values = insideBackets.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 2
                    && !values[0].Any(char.IsWhiteSpace)
                    && !values[1].Any(char.IsWhiteSpace)
                    && int.TryParse(values[0], out var value1)
                    && int.TryParse(values[1], out var value2))
                {
                    result += value1 * value2;
                }
            }

            var doIndex = mul.LastIndexOf(DO);
            var dontIndex = mul.LastIndexOf(DONT);

            if (doIndex != -1
                && doIndex > dontIndex)
            {
                doFlag = true;
            }
            else if (dontIndex != -1
                && dontIndex > doIndex)
            {
                doFlag = false;
            }
        }

        return result;
    }
}