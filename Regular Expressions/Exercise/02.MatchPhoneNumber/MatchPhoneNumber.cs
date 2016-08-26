using System;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        string pattern = @"(?<=^| )\+359( |\-)2\1\d{3}\1\d{4}\b";
        string text =  "+359 2 222 2222 359-2-222-2222, +359/2/222/2222, +359-2 222 2222 + 359 2 - 222 - 2222, +359-2-222-222, +359- 2-222-22222 +359-2-222-2222";


        Regex reg = new Regex(pattern);
        MatchCollection matches = reg.Matches(text);

        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }
}

