using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "grid.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] wordSearch;
        try
        {
            wordSearch = File.ReadAllLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return;
        }

        int countXMAS = CountOccurrences(wordSearch, "XMAS");
        Console.WriteLine($"XMAS appears {countXMAS} times.");

        int countX_MAS = CountXMASOccurrences(wordSearch);
        Console.WriteLine($"X-MAS appears {countX_MAS} times.");
    }

    static int CountOccurrences(string[] grid, string word)
    {
        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        int wordLength = word.Length;

        // Directions: right, down, down-right, down-left, left, up, up-left, up-right
        int[,] directions = { { 0, 1 }, { 1, 0 }, { 1, 1 }, { 1, -1 }, { 0, -1 }, { -1, 0 }, { -1, -1 }, { -1, 1 } };

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int d = 0; d < 8; d++)
                {
                    int x = i, y = j;
                    bool match = true;

                    for (int k = 0; k < wordLength; k++)
                    {
                        if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x][y] != word[k])
                        {
                            match = false;
                            break;
                        }
                        x += directions[d, 0];
                        y += directions[d, 1];
                    }

                    if (match)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    static int CountXMASOccurrences(string[] grid)
    {
        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 1; j++)
            {
                if (grid[i][j] == 'A')
                {
                    // Check for X-MAS pattern
                    bool isXMAS =
                        ((grid[i - 1][j - 1] == 'M' && grid[i + 1][j + 1] == 'S') || (grid[i - 1][j - 1] == 'S' && grid[i + 1][j + 1] == 'M')) &&
                        ((grid[i - 1][j + 1] == 'M' && grid[i + 1][j - 1] == 'S') || (grid[i - 1][j + 1] == 'S' && grid[i + 1][j - 1] == 'M'));

                    if (isXMAS)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}