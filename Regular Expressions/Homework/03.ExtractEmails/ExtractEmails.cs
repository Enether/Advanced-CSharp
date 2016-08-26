using System;
using System.Text.RegularExpressions;


class ExtractEmails
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"[a-zA-Z0-9][^ ]+[a-zA-Z0-9]{1}@\w{1}[^ ]+\.[^ ]+\w{1}";
        Regex findEmails = new Regex(pattern);
        MatchCollection emails = findEmails.Matches(input);

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}

