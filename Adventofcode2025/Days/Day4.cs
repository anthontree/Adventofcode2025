
namespace Adventofcode2025.Days;

public static class Day4
{
    public static double Part1(IEnumerable<string> input)
    {
        double result = 0;
        List<string> list = input.ToList();
        int rows = input.Count();
        int cols = input.First().Length;
        char[,] grid = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                grid[row, col] = list[row][col];
            }
        }
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] == '@')
                {                   
                    if (CheckRolls(rows, cols, row, col, grid) < 4)
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
                        if (CheckRolls(rows, cols, row, col, grid) < 4)
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

    private static int CheckRolls(int rows, int cols, int row, int col, char[,] grid)
    {
        int adjRolls = 0;

        #region check
        if (col + 1 < cols)
        {
            adjRolls += grid[row, col + 1] == '@' ? 1 : 0;
        }
        if (col - 1 >= 0)
        {
            adjRolls += grid[row, col - 1] == '@' ? 1 : 0;
        }
        if (col + 1 < cols && row + 1 < rows)
        {
            adjRolls += grid[row + 1, col + 1] == '@' ? 1 : 0;
        }
        if (col - 1 >= 0 && row + 1 < rows)
        {
            adjRolls += grid[row + 1, col - 1] == '@' ? 1 : 0;
        }
        if (col + 1 < cols && row - 1 >= 0)
        {
            adjRolls += grid[row - 1, col + 1] == '@' ? 1 : 0;
        }
        if (col - 1 >= 0 && row - 1 >= 0)
        {
            adjRolls += grid[row - 1, col - 1] == '@' ? 1 : 0;
        }
        if (row + 1 < rows)
        {
            adjRolls += grid[row + 1, col] == '@' ? 1 : 0;
        }
        if (row - 1 >= 0)
        {
            adjRolls += grid[row - 1, col] == '@' ? 1 : 0;
        }
        #endregion

        return adjRolls;
    }
}
