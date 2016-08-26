using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(EncodeCharacters(input));
    }
    static string EncodeCharacters(string value)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in value)
        {
            string encodedValue = "\\u" + ((int)c).ToString("x4");
            sb.Append(encodedValue);
        }
        return sb.ToString();
    }
}

