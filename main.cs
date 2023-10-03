using System;

class Program {
    static void Main(string[] args)
    {
        Console.Write("Enter a word: ");
        string a = Console.ReadLine();
        
        Console.Write("Enter another word: ");
        string b = Console.ReadLine();

        int LevenshteinDistance = CalculateLevenshteinDistance(a, b);

        Console.WriteLine($"Levenshtein distance is: {LevenshteinDistance}");
    }

    static int CalculateLevenshteinDistance(string a, string b) {
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
