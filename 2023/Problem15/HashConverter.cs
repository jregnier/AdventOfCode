using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AocUtilities;


namespace Problem15;

internal class HashConverter
{
    public int SolvePart1(string input)
    {
        var result = 0;

        foreach (var item in Parse(input))
        {
            foreach (var code in Encoding.ASCII.GetBytes(item))
            {
                result += code;
                result *= 17;
                result %= 256;
            }
        }

        return result;
    }

    public int SolvePart2(string input)
    {
        return 1;
    }

    public List<string> Parse(string input)
    {
        return InputReader.GetCommaSeparated(input);
    }
}
