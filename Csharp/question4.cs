using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] tab = LoadTab(); // Load your dictionary array from a data source.

        string filePath = "Texte.txt";
        string outputFilePath = "Texte.err";

        string[] separators = { " ", "." };

        string[] words;
        List<string> cleanedWords = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string text = reader.ReadToEnd();
            words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        foreach (string word in words)
        {
            string cleanedWord = word.Trim(".,!?").ToLower();
            cleanedWords.Add(cleanedWord);
        }

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string badWord in cleanedWords)
            {
                if (tab.Contains(badWord))
                {
                    Console.WriteLine($"skype {badWord}");
                    continue;
                }
                else
                {
                    string line = $"{badWord}-";
                    string[] suggestions = ProposeLevenshtein(badWord, tab);
                    line += string.Join(", ", suggestions);
                    line += "\n";
                    writer.Write(line);
                }
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

    static string[] ProposeLevenshtein(string x, string[] tab)
    {
        int COEFFICIENT_MAX = 2;
        List<string> suggestions = new List<string>();

        foreach (string y in tab)
        {
            int distance = CalculateLevenshteinDistance(x, y);
            if (distance <= COEFFICIENT_MAX)
            {
                suggestions.Add(y);
            }
        }

        return suggestions.ToArray();
    }

    static int CalculateLevenshteinDistance(string a, string b)
    {
        // Levenshtein distance calculation code as shown in previous responses.
        // You can reuse the CalculateLevenshteinDistance method from earlier.
    }
}
