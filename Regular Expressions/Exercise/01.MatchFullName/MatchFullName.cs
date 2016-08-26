using System;
using System.Text.RegularExpressions;

class MatchFullName
{
    static void Main()
    {
        string text = "Ivan Ivanov, ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan	Ivanov";
        string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";
        Regex te = new Regex(pattern);
        MatchCollection matches = te.Matches(text);

        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }
}

