using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class PhoneNumbers
{
    static void Main()
    {
        string pattern = @"(?<name>[A-Z][A-Za-z]*)[^A-Za-z\+]*?(?<number>\+*[0-9]+[\(\)\/\.\- 0-9]*[0-9]+)";
        Regex rex = new Regex(pattern);
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
                break;

            sb.AppendLine(input);
        }

        List<Tuple<string, string>> results = new List<Tuple<string, string>>();
        string inputStr = sb.ToString();
        Match match = rex.Match(inputStr);
        bool thereIsAMatch = match.Value != "";

        if (thereIsAMatch)
        {
            while (true)
            {
                if (match.Value == "")
                    break;

                string name = match.Groups["name"].Value;
                string number = match.Groups["number"].Value;
                number = Regex.Replace(number, @"[\/ \(\)\.\-\/]", "");

                results.Add(new Tuple<string, string>(name, number));

                match = match.NextMatch();
            }

            Console.Write("<ol>");
            foreach (var tuple in results)
            {
                Console.Write("<li><b>{0}:</b> {1}</li>", tuple.Item1, tuple.Item2);
            }
            Console.Write("</ol>");
        }
        else
        {
            Console.WriteLine("<p>No matches!</p>");
        }

    }
}

