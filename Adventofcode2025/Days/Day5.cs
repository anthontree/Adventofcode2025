
namespace Adventofcode2025.Days;

public static class Day5
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        var lows = Lows(input);
        var highs = Highs(input);
        var ids = Ids(input);
        foreach (var id in ids)
        {
            for (int i = 0; i < lows.Count; i++)
            {
                if (id >= lows[i] && id <= highs[i])
                {
                    result++;
                    break;
                }
            }
        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        double result = 0;
        var lows = Lows(input);
        var highs = Highs(input);
        bool test = true;
        while (test)
        {
            test = CombineRanges(lows, highs, 0);
        }
        for (int i = 0; i < lows.Count; i++)
        {
            result += (highs[i] - lows[i]) + 1;
        }
        return result;
    }

    public static List<double> Lows(IEnumerable<string> input)
    {
        List<double> results = new();
        foreach (string line in input)
        {
            if (line.Contains("-"))
            {
                var parts = line.Split("-");
                if (double.TryParse(parts[0], out double low))
                {
                    results.Add(low);
                }
            }
        }
        return results;
    }
    public static List<double> Highs(IEnumerable<string> input)
    {
        List<double> results = new();
        foreach (string line in input)
        {
            if (line.Contains("-"))
            {
                var parts = line.Split("-");
                if (double.TryParse(parts[1], out double high))
                {
                    results.Add(high);
                }
            }
        }
        return results;
    }
    public static List<double> Ids(IEnumerable<string> input)
    {
        List<double> results = new();
        foreach (string line in input)
        {
            if (!line.Contains("-") && !string.IsNullOrEmpty(line))
            {
                if (double.TryParse(line, out double id))
                {
                    results.Add(id);
                }
            }
        }
        return results;
    }
    public static bool IsOverlap(double low1, double high1, double low2, double high2)
    {
        return (low1 >= low2 && low1 <= high2) || (high1 >= low2 && high1 <= high2)
        || (low2 >= low1 && low2 <= high1) || (high2 >= low1 && high2 <= high1);
    }
    public static bool CombineRanges(List<double> lows, List<double> highs, int i)
    {
        bool overlapFound = false;
        double low = lows[i];
        double high = highs[i];
        var toRemove = new List<int>();
        for (int j = i + 1; j < lows.Count; j++)
        {
            var tempLow = lows[j];
            var tempHigh = highs[j];
            if (IsOverlap(low, high, tempLow, tempHigh))
            {
                overlapFound = true;
                low = Math.Min(low, lows[j]);
                high = Math.Max(high, highs[j]);
                toRemove.Add(j);
            }
        }
        lows[i] = low;
        highs[i] = high;
        foreach (var index in toRemove.OrderByDescending(x => x))
        {
            lows.RemoveAt(index);
            highs.RemoveAt(index);
        }
        if (i < lows.Count - 1)
        {
            return overlapFound || CombineRanges(lows, highs, i + 1);
        }
        else
        {
            return overlapFound;
        }
    }
}
