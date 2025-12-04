
namespace Adventofcode2025.Days;

public static class Day1
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        int position = 50;
        foreach (string line in input)
        {
            char direction = line[0];
            int num = Convert.ToInt32(line.Substring(1, line.Length - 1));
            num = num % 100;
            if (direction == 'L')
            {
                if (num > position)
                {
                    position = 100 + position - num;
                }
                else
                {
                    position = position - num;
                }
            }
            else
            {
                if (num + position > 99)
                {
                    position = position + num - 100;
                }
                else
                {
                    position = position + num;
                }
            }

            if(position == 0)
            {
                result++;
            }
        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        double result = 0;
        int position = 50;
        foreach (string line in input)
        {
            char direction = line[0];
            int num = Convert.ToInt32(line.Substring(1, line.Length - 1));
            if(num > 100)
            {
                int hundreds = num / 100;
                result += hundreds;
                num = num % 100;
            }

            if (direction == 'L')
            {
                if (num > position)
                {
                    int prev = position;
                    position = 100 + position - num;
                    if(position !=0 && prev != 0)
                    {
                        result++;
                    }
                }
                else
                {
                    position = position - num;
                }
            }
            else
            {
                if (num + position > 99)
                {
                    position = position + num - 100;
                    if (position != 0)
                    {
                        result++;
                    }
                }
                else
                {
                    position = position + num;
                }
            }

            if (position == 0)
            {
                result++;
            }
        }
        return result;
    }
}
