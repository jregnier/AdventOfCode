namespace Day7;

internal record Equation(
    long TestValue,
    long[] Numbers);

internal class CalibrationEquations
{
    public List<Equation> Equations { get; init; } = [];

    public long Solve1()
    {
        var result = new HashSet<Equation>();
        foreach (var equation in Equations)
        {
            if (ValidateEquation1(equation.TestValue, equation.Numbers))
            {
                result.Add(equation);
            }
        }

        return result.Sum(x => x.TestValue);
    }

    public long Solve2()
    {
        var result = new HashSet<Equation>();
        foreach (var equation in Equations)
        {
            if (ValidateEquation2(equation.TestValue, equation.Numbers))
            {
                result.Add(equation);
            }
        }

        return result.Sum(x => x.TestValue);
    }

    private static bool ValidateEquation1(long testValue, long[] numbers) =>
        ValidateEquation1(testValue, numbers, 1, numbers[0]);

    private static bool ValidateEquation1(long testValue, long[] numbers, int currentIndex, long total)
    {
        if (currentIndex == numbers.Length)
        {
            return total == testValue;
        }

        if (ValidateEquation1(testValue, numbers, currentIndex + 1, total + numbers[currentIndex]))
        {
            return true;
        }

        if (ValidateEquation1(testValue, numbers, currentIndex + 1, total * numbers[currentIndex]))
        {
            return true;
        }

        return false;
    }

    private static bool ValidateEquation2(long testValue, long[] numbers) =>
        ValidateEquation2(testValue, numbers, 1, numbers[0]);

    private static bool ValidateEquation2(long testValue, long[] numbers, int currentIndex, long total)
    {
        if (currentIndex == numbers.Length)
        {
            return total == testValue;
        }

        if (ValidateEquation2(testValue, numbers, currentIndex + 1, total + numbers[currentIndex]))
        {
            return true;
        }

        if (ValidateEquation2(testValue, numbers, currentIndex + 1, total * numbers[currentIndex]))
        {
            return true;
        }

        if (ValidateEquation2(testValue, numbers, currentIndex + 1, CombineNumbers(total, numbers[currentIndex])))
        {
            return true;
        }

        return false;
    }

    private static long CombineNumbers(long num1, long num2) =>
        long.Parse($"{num1}{num2}");

    public static CalibrationEquations Parse(string content)
    {
        var equations = new List<Equation>();

        foreach (var line in AocUtilities.InputReader.GetLines(content))
        {
            var testValueSplit = line.Split(":");
            var testValue = long.Parse(testValueSplit[0]);

            var numbers = testValueSplit[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    return long.TryParse(x, out var value)
                    ? value
                    : 0;
                })
                .ToArray();

            equations.Add(new Equation(testValue, numbers));
        }

        return new CalibrationEquations
        {
            Equations = equations
        };
    }
}