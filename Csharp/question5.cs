using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<string> tiv = new List<string>();
        using (StreamReader file = new StreamReader("gutenberg.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                tiv.Add(line.Trim());
            }
        }

        List<string> tab = new List<string>();
        using (StreamReader file = new StreamReader("liste_francais.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                tab.Add(line.Trim());
            }
        }

        int resultat = 0;

        for (int i = tab.Count; i < tiv.Count - 2; i++)
        {
            resultat += tiv[i].Length;
        }

        for (int i = 0; i < Math.Min(tab.Count, tiv.Count); i++)
        {
            resultat += LevenshteinDistance(tab[i], tiv[i]);
        }

        Console.WriteLine(resultat); // 2871815 et plus DistanceLevenshtein(fr, gut)
    }

    static int LevenshteinDistance(string a, string b)
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
