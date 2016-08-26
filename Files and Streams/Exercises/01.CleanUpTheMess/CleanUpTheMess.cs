using System;
using System.IO;
using System.Text.RegularExpressions;

class CleanUpTheMess
{
    const string pattern = @"";
    static void Main()
    {
        string newLinePattern = @"\s+\n\s*";
        string separateStatementsPattern = @";\s*";
        string _01curlyBracketsPattern = @"\s*{\s*";
        string _02curlyBracketsPattern = @"\s*}\s*";
        string dotsPattern = @"\s*\.\s*";
        using (StreamReader sr = new StreamReader("../../Mecanismo.cs"))
        {
            using(StreamWriter sw = new StreamWriter("../../Engine.cs"))
            {
                Regex rex = new Regex(pattern);
                string currentLine = sr.ReadToEnd();
                currentLine = Regex.Replace(currentLine, newLinePattern, Environment.NewLine);
                currentLine = Regex.Replace(currentLine, separateStatementsPattern, ";" + Environment.NewLine);
                currentLine = Regex.Replace(currentLine, _01curlyBracketsPattern, Environment.NewLine + "{" + Environment.NewLine);
                currentLine = Regex.Replace(currentLine, _02curlyBracketsPattern, Environment.NewLine + "}" + Environment.NewLine);
                currentLine = Regex.Replace(currentLine, dotsPattern, ".");

                sw.WriteLine(currentLine);
            }
        }
    }
}

