using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] tab = LoadTab(); // Load your dictionary array from a data source.

        Console.Write("Veuillez insérer un mot:");
        string x = Console.ReadLine();

        int COEFFICIENT_MAX = 2;

        Console.WriteLine("Voici quelques propositions:");
        foreach (string y in tab)
        {
            int distance = CalculateLevenshteinDistance(x, y);
            if (distance < COEFFICIENT_MAX)
            {
                Console.WriteLine($"\t{y}");
            }
        }
    }

    static string[] LoadTab()
    {
        // Implement a method here to load the 'tab' array from your data source.
        // For example, you can read it from a file or database.
        // Replace the return statement with the actual data loading logic.
        string[] tab = new string[] { "apple", "banana", "cherry", "date" };
        return tab;
    }

    static int CalculateLevenshteinDistance(string a, string b)
    {
        int[,] distances = new int[a.Length + 1, b.Length + 1];

        for (int i = 0; i <= a.Length; i++)
        {
            for (int j = 0; j <= b.Length; j++)
            {
                if (i == 0)
                {
                    distances[i, j] = j;
                }
                else if (j == 0)
                {
                    distances[i, j] = i;
                }
                else
                {
                    int substitutionCost = (a[i - 1] != b[j - 1]) ? 1 : 0;

                    distances[i, j] = Math.Min(
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + substitutionCost
                    );
                }
            }
        }

        return distances[a.Length, b.Length];
    }
}
