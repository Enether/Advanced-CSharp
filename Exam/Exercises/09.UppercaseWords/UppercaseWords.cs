using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
class UppercaseWords
{
    static void Main()
    {
        string pattern = @"(?<grpOne>[^A-Za-z\n\r]*)(?<word>[a-zA-Z]+)(?<grpTwo>[^A-Za-z\n\r]*)";
        Regex rex = new Regex(pattern);
        
        while (true)
        {
            string inputLine = Console.ReadLine();

            if (inputLine == "END")
                break;

            Match match = rex.Match(inputLine);

            while (match.Groups["word"].Value != "") // iterates all the words
            {
                string word = match.Groups["word"].Value;

                if (wordIsUpperCase(word)) // checks if the word is all in uppercase and does the appropriate actions if so
                {
                    string oldWord = word;
                    word = ReverseWord(word);

                    if (oldWord.Equals(word)) // checks if the word is the same after being reversed and does the appropriate actions if so
                        word = DoubleLetters(word);
                }

                Console.Write(SecurityElement.Escape(match.Groups["grpOne"].Value + word + match.Groups["grpTwo"].Value));

                match = match.NextMatch();
            }
            Console.WriteLine();
        }
    }
    public static bool wordIsUpperCase(string word)
    {
        bool isUpper = true;

        foreach (char character in word)
        {
            if (Char.IsLower(character))
            {
                isUpper = false;
                break;
            }
        }

        return isUpper;
    }
    public static string ReverseWord(string word)
    {
        string oldWord = word;
        StringBuilder newWordSB = new StringBuilder();

        for (int i = oldWord.Length-1; i >= 0; i--)
        {
            newWordSB.Append(oldWord[i]);
        }

        return newWordSB.ToString();
    }
    public static string DoubleLetters(string word)
    {
        string oldWord = word;
        StringBuilder doubleLettersSB = new StringBuilder();

        for (int i = 0; i < oldWord.Length; i++)
        {
            doubleLettersSB.Append(oldWord[i]);
            doubleLettersSB.Append(oldWord[i]);
        }

        return doubleLettersSB.ToString();
    }
}

