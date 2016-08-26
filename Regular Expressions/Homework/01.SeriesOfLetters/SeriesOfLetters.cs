using System;
using System.Text.RegularExpressions;


class SeriesOfLetters
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = @"(.)\1*";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);
        foreach (var item in matches)
        {
            string character = item.ToString();
            Console.Write(character[0]);
        }
        Console.WriteLine();
    }
}

