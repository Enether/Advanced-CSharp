using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        // 50/100
        static void Main(string[] args)
        {
            string myPattern = @"<a.*href\s*=(\s|\n)*?(?<te>""|\s+?|')*(.*?)\k<te>.*>";
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                    break;

                sb.AppendLine(line);
            }

            string text = sb.ToString();
            Regex rex = new Regex(myPattern);
            Match match = rex.Match(text);
            while (true)
            {
                if (match.ToString() == "")
                    break;

                Console.WriteLine(match.Groups[2].ToString());

                match = match.NextMatch();
            }
        }
    }
}
