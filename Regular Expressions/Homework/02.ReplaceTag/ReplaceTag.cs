using System;
using System.Text.RegularExpressions;


    class ReplaceTag
    {
        static void Main(string[] args)
        {
            string text = @" <ul> 
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul> "; // can't read the text from the console properly with the new lines, that's why I have it set to the specific text
            string firstPattern = @"<a";
            string firstReplacement = @"[URL";
            Regex firstTag = new Regex(firstPattern);

            string secondPattern = @"<\/a>";
            string secondReplacement = @"[/URL]";
            Regex secondTag = new Regex(secondPattern);

            text = Regex.Replace(text, firstPattern, firstReplacement);
            text = Regex.Replace(text, secondPattern, secondReplacement);
            Console.WriteLine(text);
        }
    }

