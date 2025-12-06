
namespace Adventofcode2025.Days;

public static class Day6
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        List<List<string>> grid = new List<List<string>>();

        foreach (string line in input)
        {
            List<string> row = new List<string>();
            var split = line.Split(' ');
            foreach (var s in split)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    row.Add(s);
                }
            }
            grid.Add(row);
        }

        for (int i = 0; i < grid.First().Count; i++)
        {
            if (grid[4][i] == "*")
            {
                result += Convert.ToDouble(grid[0][i]) *
                Convert.ToDouble(grid[1][i]) *
                Convert.ToDouble(grid[2][i]) *
                Convert.ToDouble(grid[3][i]);
            }
            else
            {
                result += Convert.ToDouble(grid[0][i]) +
                Convert.ToDouble(grid[1][i]) +
                Convert.ToDouble(grid[2][i]) +
                Convert.ToDouble(grid[3][i]);
            }
        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        double result = 0;
        double curResult = 0;
        var cur = '+';
        List<string> grid = input.ToList();

        for (int i = 0; i < grid.First().Length; i++)
        {
            var col = GetCol(grid, i);
            if(string.IsNullOrEmpty(col))
            {
                continue;
            }
            if (grid[4][i] == '*')
            {
                result += curResult;
                curResult = 1;
                cur = '*';
                curResult *= Convert.ToDouble(col);
            }
            else if(grid[4][i] == '+')
            {
                result += curResult;
                curResult = 0;
                cur = '+';
                result += Convert.ToDouble(col);
            }
            else if(cur == '+')
            {
                result += Convert.ToDouble(col);
            }
            else if(cur == '*')
            {
                curResult *= Convert.ToDouble(col);
            }
        }
        return result;
    }

    public static string GetCol(List<string> grid, int i)
    {
        var d = (string.IsNullOrEmpty(grid[0][i].ToString()) ? "" : grid[0][i].ToString());
        var e = (string.IsNullOrEmpty(grid[1][i].ToString()) ? "" : grid[1][i].ToString());
        var f = (string.IsNullOrEmpty(grid[2][i].ToString()) ? "" : grid[2][i].ToString());
        var g = (string.IsNullOrEmpty(grid[3][i].ToString()) ? "" : grid[3][i].ToString());
        string res = d + e + f + g;
        return res.Trim();

    }
}
