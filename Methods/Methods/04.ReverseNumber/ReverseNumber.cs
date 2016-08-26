using System;
using System.Collections.Generic;
using System.Linq;
class ReverseNumber
{
    static void Main()
    {
        Console.WriteLine(GetReversedNumber());
        Console.WriteLine(GetReversedNumber());
        Console.WriteLine(GetReversedNumber());
    }
    static double GetReversedNumber()
    {

        List<char> toReverse = Console.ReadLine().ToCharArray().ToList();
        toReverse.Reverse();
        string temp = "";
        foreach (var digit in toReverse)
        {
            temp += digit;
        }
        double number = double.Parse(temp);
        return number;
    }
}

