using System;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        string key = Console.ReadLine();
        string pattern = @"[A-Z][a-z ]+" + key + @"[a-z ]+(!|\.|\?)";
        string text = Console.ReadLine();

        Regex findSentences = new Regex(pattern);
        MatchCollection sentences = findSentences.Matches(text);

        foreach (var sentence in sentences)
        {
            Console.WriteLine(sentence);
        }
    }
}

