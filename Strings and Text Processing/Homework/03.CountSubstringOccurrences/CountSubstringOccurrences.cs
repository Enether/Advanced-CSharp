using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string searchTerm = Console.ReadLine();

        Console.WriteLine(FindOccurrences(text,searchTerm));
    }
    static int FindOccurrences(string text, string searchTerm)
    {
        int count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if(i + searchTerm.Length <= text.Length)
            {
                if (text.Substring(i, searchTerm.Length) == searchTerm)
                    count++;
            }

        }

        return count;
    }
}

