
namespace Adventofcode2025.Days;

public static class Day3
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        foreach (string line in input)
        {
            if (line != null)
            {
                int first = -1;
                int index = 0;
                int last = -1;
                var arr = line.ToCharArray();
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    char? c = arr[i];
                    int num = -1;
                    if (int.TryParse(c.ToString(), out num))
                    {
                        if (num > first)
                        {
                            first = num;
                            index = i;
                        }
                    }
                }
                for (int i = index + 1; i < arr.Length; i++)
                {
                    char? c = arr[i];
                    int num = -1;
                    if (int.TryParse(c.ToString(), out num))
                    {
                        if (num > last)
                        {
                            last = num;
                        }
                    }
                }

                result += first * 10 + last;
            }

        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        int digitCount = 12;
        double result = 0;
        foreach (string line in input)
        {
            if (line != null)
            {
                string digitsStr = "";
                int index = 0;
                var arr = line.ToCharArray();
                for (int dc = 0; dc < digitCount; dc++)
                {
                    int z = -1;
                    var subtractIndex = digitCount - 1 - dc;
                    var maxIndex = arr.Length - subtractIndex;
                    for (int i = index; i < maxIndex; i++)
                    {
                        char? c = arr[i];
                        int num = -1;
                        if (int.TryParse(c.ToString(), out num))
                        {
                            if (num > z)
                            {
                                z = num;
                                index = i + 1;
                            }
                        }
                    }
                    digitsStr += z.ToString();
                }
                double lineResult = 0;
                var t = double.TryParse(digitsStr, out lineResult);
                result += lineResult;
            }
        }
        return result;
    }
}
