using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class TextTransformer
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "burp")
                break;
            else
                sb.Append(input);
        }

        // 0/100, problem was in regex below, needed to be \s{2,} not \s+, which i don't think i would have done on my own
        string message = Regex.Replace(sb.ToString(), @"\s{2,}", " ");
        string pattern = @"(?<symbol>[$%&'])(?<info>[^$%&']+)(\2)";
        Regex rex = new Regex(pattern);
        MatchCollection matches = rex.Matches(message);

        List<string> results = new List<string>();

        foreach (Match match in matches)
        {
            StringBuilder buildResult = new StringBuilder();

            string specialString = match.Groups["info"].Value;
            char specialSymbol = char.Parse(match.Groups["symbol"].Value);
            int specialSymbolWeight = 0;
            switch (specialSymbol)
            {
                case '$':
                    specialSymbolWeight = 1;
                    break;
                case '%':
                    specialSymbolWeight = 2;
                    break;
                case '&':
                    specialSymbolWeight = 3;
                    break;
                case '\'':
                    specialSymbolWeight = 4;
                    break;

            }
            for (int i = 0; i < specialString.Length; i++)
            {
                if(i % 2 == 0)
                {
                    char newSymbol = Convert.ToChar(specialString[i] + specialSymbolWeight);
                    buildResult.Append(newSymbol);
                }
                else
                {
                    char newSymbol = Convert.ToChar(specialString[i] - specialSymbolWeight);
                    buildResult.Append(newSymbol);
                }
            }
            results.Add(buildResult.ToString());
        }

        Console.WriteLine(string.Join(" ", results));
    }
}

