using System;

class TextFilter
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        text = ReplaceWords(bannedWords, text);
       
        Console.WriteLine(text);
    }
    static string ReplaceWords(string[] bannedWords, string text)
    {

        for (int i = 0; i < bannedWords.Length; i++)
        {
            string bannedWord = bannedWords[i];
            text = text.Replace(bannedWord, new string('*', bannedWord.Length));
        }

        return text;
    }
}

