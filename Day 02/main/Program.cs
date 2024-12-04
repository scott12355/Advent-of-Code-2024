using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main()
    {
        string filePath = "data.txt"; // Path to your text file

        // List to store the parsed data
        List<List<int>> parsedData = readData(filePath);

        int safeReportsPart1 = parsedData.Count(IsReportSafe);
        int safeReportsPart2 = parsedData.Count(report => IsReportSafe(report) || CanBeSafeWithOneRemoval(report));

        Console.WriteLine($"Part 1: {safeReportsPart1} reports are safe.");
        Console.WriteLine($"Part 2: {safeReportsPart2} reports are safe with the Problem Dampener.");
    }

    static bool IsReportSafe(List<int> levels)
    {
        bool isAscending = true, isDescending = true;

        for (int i = 0; i < levels.Count - 1; i++)
        {
            int diff = levels[i + 1] - levels[i];
            if (diff < -3 || diff > 3 || diff == 0) return false; // Invalid difference
            if (diff > 0) isDescending = false; // Breaks descending order
            if (diff < 0) isAscending = false;  // Breaks ascending order
        }

        return isAscending || isDescending;
    }

    static bool CanBeSafeWithOneRemoval(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var modifiedLevels = levels.Where((_, index) => index != i).ToList();
            if (IsReportSafe(modifiedLevels)) return true;
        }
        return false;
    }



    static List<List<int>> readData(string filename)
    {
        try
        {
            List<List<int>> data = new List<List<int>>();
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                // Split the line into numbers and convert them to integers
                string[] parts = line.Split(' ');
                List<int> numbers = new List<int>();

                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        numbers.Add(number);
                    }
                }

                // Add the parsed list to the data collection
                data.Add(numbers);
            }

            // Output the data to verify
            Console.WriteLine("Parsed Data:");
            foreach (var row in data)
            {
                // Console.WriteLine(string.Join(" ", row));
            }
            return data;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<List<int>>();
        }
    }
}
