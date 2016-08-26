using System;
using System.Text;

class StringLength
{
    static void Main()
    {
        string input = ReturnCutInput(Console.ReadLine());
        Console.WriteLine(input);
    }
    static string ReturnCutInput(string input)
    {
        StringBuilder cutInput = new StringBuilder();
        int iterator = 0;

        while (cutInput.Length < 20 && iterator < input.Length)
        {
            cutInput.Append(input[iterator]);
            iterator++;
        }

        if (cutInput.Length < 20)
            FillWithAsterisks(ref cutInput);
        return cutInput.ToString();
    }
    static void FillWithAsterisks(ref StringBuilder cutInput)
    {
        while (cutInput.Length < 20)
            cutInput.Append("*");
    }
}

