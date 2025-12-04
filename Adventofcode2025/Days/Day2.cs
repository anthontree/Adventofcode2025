
namespace Adventofcode2025.Days;

public static class Day2
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        List<string> ranges = input.First().Split(',').ToList();
        foreach (string range in ranges)
        {
            double start = Convert.ToDouble(range.Split("-")[0]);
            double end = Convert.ToDouble(range.Split("-")[1]);
            for (double i = start; i <= end; i++)
            {
                string id = i.ToString();
                if (id.Length % 2 == 0) 
                {
                    int half = id.Length / 2;
                    string id1 = id.Substring(0, half);
                    string id2 = id.Substring(half, half);
                    if (id1==id2)
                    {
                        result += i;
                    }
                }
            }
        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        double result = 0;
        List<string> ranges = input.First().Split(',').ToList();
        foreach (string range in ranges)
        {
            double start = Convert.ToDouble(range.Split("-")[0]);
            double end = Convert.ToDouble(range.Split("-")[1]);
            for (double i = start; i <= end; i++)
            {
                bool wasInvalid = false;
                string id = i.ToString();
                int half = id.Length / 2;
                for(int digits = 1;digits <=half;digits++)
                {
                    if(wasInvalid)
                    {
                        break;
                    }
                    if (id.Length % digits == 0)
                    {
                        List<string> subs = new List<string>();
                        for (int sub = 0; sub + digits <= id.Length; sub+=digits)
                        {
                            subs.Add(id.Substring(sub, digits));
                        }
                        bool equal = true;
                        foreach (string s in subs)
                        {
                            equal &= s.Equals(subs.First());
                        }
                        if(equal)
                        {
                            result += i;
                            wasInvalid = true;
                        }
                    }
                }
            }
        }
        return result;
    }
}
