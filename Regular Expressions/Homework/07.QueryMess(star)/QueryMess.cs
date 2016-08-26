using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _07.QueryMess_star_
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=^|&|\?|)(?<field>[^%20\+&=\?\s\+]+)(?:\+|%20|&|\?)*(?:=)(?:%20|\+|&|\?|\+)*(?<value>[^&\s]+)(?:%20|\+|&|\?|\+)*";
            Regex rex = new Regex(pattern);
            string text = "";

            while (true)    // read
            {
                Dictionary<string, List<string>> query = new Dictionary<string, List<string>>();
                string input = Console.ReadLine();

                if (input == "END")
                    break;

                text = input;

                Match findPair = rex.Match(text);
                query = SaveValues(query, findPair);
                WriteLine(query);
            }
        }
        static void WriteLine(Dictionary<string, List<string>> query)
        {
            foreach (var item in query)
            {
                Console.Write("{0}=[{1}]", item.Key, string.Join<string>(", ", item.Value));
            }
            Console.WriteLine();
        }
        static Dictionary<string, List<string>> SaveValues(Dictionary<string, List<string>> query, Match findPair)
        {
            while (findPair.ToString() != "") // save values
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(findPair.Groups["value"]);

                sb.Replace("%20", " ");
                sb.Replace("+", " ");
                string value = sb.ToString().Trim();
                string field = findPair.Groups["field"].ToString();
                value = Regex.Replace(value, @"\s+", " ");

                if (query.ContainsKey(field))
                    query[field].Add(value);
                else
                {
                    query[field] = new List<string>();
                    query[field].Add(value);
                }
                findPair = findPair.NextMatch();
            }
            return query;
        }
    }
}
