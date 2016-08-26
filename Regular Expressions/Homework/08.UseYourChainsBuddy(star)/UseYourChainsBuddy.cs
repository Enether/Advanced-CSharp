using System;
using System.IO;
using System.Text.RegularExpressions;

class UseYourChainsBuddy
{
    static void Main()
    {
        int bufSize = 1024;
        Stream inStream = Console.OpenStandardInput(bufSize);
        Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
        // Used to increase the default maximum length of Console.Readline(), because it was not enough.
       
        string input = Console.ReadLine();
        string pattern = @"(?:<p>)(?<text>.+?)(?:<\/p>)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        string text = "";

        foreach (var match in matches)
        {
            Match encryptedText = (Match)match;
            string line = encryptedText.Groups["text"].ToString();
            text += ConvertString(line);
        }

        text = Regex.Replace(text, @"\s+", " "); //  replaces duplicate spaces with only one
        Console.WriteLine(text);
       
    }
    static string ConvertString(string text)
    {
        string newText = "";
        foreach (char character in text)
        {
            int charPosition = Convert.ToInt32(character);

            if (charPosition > 122 || (charPosition < 97 && (charPosition < 48 || charPosition > 57))) // change character to space if it's not a smallletter or number
                newText += ' ';
            else if(charPosition <= 122 && charPosition >= 97) // change letter
            {
                if (charPosition < 110)
                    newText += Convert.ToChar(Convert.ToInt32(charPosition + 13));
                else
                    newText += Convert.ToChar(Convert.ToInt32(charPosition - 13));
            }
            else // it's a number
            {
                newText += character;
            }

        }
        return newText;
    }
}

