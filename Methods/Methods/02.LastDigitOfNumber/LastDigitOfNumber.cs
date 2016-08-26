using System;
class LastDigitOfNumber
{
    static void Main()
    {
        Console.WriteLine(GetLastDigitAsWord(512));
        Console.WriteLine(GetLastDigitAsWord(1024));
        Console.WriteLine(GetLastDigitAsWord(12309));
    }
    static string GetLastDigitAsWord(int n)
    { 
        char[] digits = n.ToString().ToCharArray();
        string word = FindLastDigit(digits);
        return word;
    }
    static string FindLastDigit(char[] digits)
    {
        string word = "";
        switch (digits[digits.Length - 1])
        {
            case '0':
                word = "zero";
                break;
            case '1':
                word = "one";
                break;
            case '2':
                word = "two";
                break;
            case '3':
                word = "three";
                break;
            case '4':
                word = "four";
                break;
            case '5':
                word = "five";
                break;
            case '6':
                word = "six";
                break;
            case '7':
                word = "seven";
                break;
            case '8':
                word = "eight";
                break;
            case '9':
                word = "nine";
                break;
        }
        return word;
    }
}

