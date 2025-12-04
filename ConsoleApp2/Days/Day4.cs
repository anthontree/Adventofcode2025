
namespace Adventofcode2025.Days;

public static class Day4
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        List<string> grid = input.ToList();
        for (int row = 0; row < grid.Count; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == '@')
                {
                    int adjRolls = 0;
                    try
                    {
                        adjRolls += grid[row][col + 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row][col - 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row + 1][col + 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row + 1][col - 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row - 1][col + 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row - 1][col - 1] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row + 1][col] == '@' ? 1 : 0;
                    }
                    catch { }
                    try
                    {
                        adjRolls += grid[row - 1][col] == '@' ? 1 : 0;
                    }
                    catch { }
                    if (adjRolls < 4)
                    {
                        result++;
                    }
                }
            }
        }
        return result;
    }

    public static double Part2(IEnumerable<string> input)
    {
        double result = 0;
        List<string> list = input.ToList();
        int rows = input.Count();
        int cols = input.First().Length;
        char[,] grid = new char[rows, cols];
        char[,] grid2 = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                grid[row, col] = list[row][col];
            }
        }
        grid2 = grid;
        bool wasRollRemoved = true;
        while (wasRollRemoved)
        {
            wasRollRemoved = false;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == '@')
                    {
                        int adjRolls = 0;

                        #region check
                        try
                        {
                            adjRolls += grid[row, col + 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row, col - 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row + 1, col + 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row + 1, col - 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row - 1, col + 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row - 1, col - 1] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row + 1, col] == '@' ? 1 : 0;
                        }
                        catch { }
                        try
                        {
                            adjRolls += grid[row - 1, col] == '@' ? 1 : 0;
                        }
                        catch { }
                        #endregion

                        if (adjRolls < 4)
                        {
                            wasRollRemoved = true;
                            result++;
                            grid2[row, col] = '.';
                        }
                    }
                }
            }
            grid = grid2;
        }

        return result;
    }
}
