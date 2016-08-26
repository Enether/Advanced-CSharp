using System;
using System.Linq;


class SortArrayOfNumbers
{
    static void Main()
    {
        int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(numbersArray);
        Console.WriteLine(string.Join(" ", numbersArray.Select(p => p.ToString())));
    }
}

