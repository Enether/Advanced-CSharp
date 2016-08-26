using System;
using System.Text;
using System.Text.RegularExpressions;

class SemantinHTML
{
    static void Main()
    {
        // 85/100 before looking at the tests
        while (true)
        {
            string inputLine = Console.ReadLine();
            string pattern = "";
            if (inputLine == "END")
                break;

            if (inputLine.Contains("</div")) // checks if it's a closing tax
            {
                pattern = @"<\/div>\s*<!--\s*(?<id>.+?)\s*-->";
                Regex rex = new Regex(pattern);
                Match mtch = rex.Match(inputLine);
                Match whitespaces = Regex.Match(inputLine, @"\s*(?=<)"); // saves the whitespaces before the HTML

                inputLine = "</" + mtch.Groups["id"].Value + ">";

                inputLine = Regex.Replace(inputLine, @"\s+", " "); // removes repeating whitespaces
                inputLine = whitespaces.Value + inputLine; // adds the whitespaces at the start
            }
            else
            {
                pattern = @"<div.*(?<id>id|class)\s*=\s*""(?<info>.+?)""";
                Regex rex = new Regex(pattern);
                Match mtch = rex.Match(inputLine);
                if(mtch.Value == "") // checks if it's a <div> tag at all
                {
                    // it's not, so we do not alter the string, we just print it out as is
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    Match whitespaces = Regex.Match(inputLine, @"\s*(?=<)"); // saves the whitespaces before the HTML
                    sb.Append("<" + mtch.Groups["info"].Value); // starts building the string

                    if (inputLine.Contains("style") || inputLine.Contains("color")) // checks if there is other info, besides it's id or class
                    {
                        pattern = @"<div\s*(?<info>.*?)\s*(?:(id|class)\s*=\s*"".*?"")\s*(?<infoo>.*?)\s*>";
                        rex = new Regex(pattern);
                        mtch = rex.Match(inputLine);

                        if(mtch.Groups["info"].Value != "")
                        {
                            sb.Append(" " + mtch.Groups["info"].Value);
                        }
                        if(mtch.Groups["infoo"].Value != "")
                        {
                            sb.Append(" " + mtch.Groups["infoo"].Value);
                        }
                    }

                    sb.Append(">");
                    inputLine = sb.ToString();
                    inputLine = Regex.Replace(inputLine, @"\s+", " ");
                    inputLine = whitespaces.Value + inputLine;
                }               
            }
     
            Console.WriteLine(inputLine);  // prints the line
     }
    }
}
