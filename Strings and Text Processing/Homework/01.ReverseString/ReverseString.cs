using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string info = ReverseStr(Console.ReadLine());
        Console.WriteLine(info);
    }
    static string ReverseStr(string s)
    {
        StringBuilder reversedString = new StringBuilder();
        for (int i = s.Length-1; i >= 0; i--)
        {
            reversedString.Append(s[i]);
        }
        return reversedString.ToString();
    }
}

