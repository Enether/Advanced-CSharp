using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


class WordCount
{
    static void Main()
    {
        using(StreamReader readWords = new StreamReader(@"..\..\words.txt"))
        {
            using (StreamReader readText = new StreamReader(@"..\..\text.txt"))
            {
                using (FileStream fs = new FileStream(@"..\..\result.txt", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string[] words = ReadWords(readWords);
                        string text = ReadText(readText);
                        List<string> results = new List<string>(FillResultsList(words, text));
                        
                        results.Sort();

                        WriteResults(results, sw);                       
                    }
                }
            }
        }
    }
    static void WriteResults(List<string> results, StreamWriter sw)
    {
        for (int i = results.Count() - 1; i >= 0; i--)
        {
            string[] splittedResults = results[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            sw.WriteLine("{0} - {1}", splittedResults[1], splittedResults[0]);
        }
    }
    static List<string> FillResultsList(string[] words, string text)
    {
        List<string> fillThis = new List<string>();
        foreach (var word in words)
        {
            string regexPattern = @"\b" + word + @"\b";
            Regex regx = new Regex(regexPattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regx.Matches(text);

            fillThis.Add(matches.Count + " " + word);
        }
        return fillThis;
    }
    static string ReadText(StreamReader sr)
    {
        string text = "";
        while (true)
        {
            string line = sr.ReadLine();
            if (line == null)
                break;
            else
                text += "\n" + line;
        }
        return text;
    }
    static string[] ReadWords(StreamReader sr)
    {
        List<string> wordsList = new List<string>();
        while (true)
        {
            string word = sr.ReadLine();
            if (word == null)
                break;
            wordsList.Add(word);
        }
        string[] words = wordsList.ToArray();
        return words;
    }
}

