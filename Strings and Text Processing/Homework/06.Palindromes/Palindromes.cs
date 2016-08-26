using System;
using System.Collections.Generic;

class Palindromes
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

        SortedSet<string> palindromes = new SortedSet<string>();

        foreach (string word in words)
        {
            string reversedWord = "";
            for (int i = word.Length-1; i >= 0; i--)
            {
                reversedWord += word[i];
            }

            if (word == reversedWord)
                palindromes.Add(word);
        }
        Console.WriteLine(string.Join(", ", palindromes));
    }
}

