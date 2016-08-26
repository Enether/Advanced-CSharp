using System;
using System.Linq;

class InsertionSort
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        for (int i = 1; i < array.Length; i++)
        {
            for (int j = i; j > 0 && array[j-1] > array[j]; j--)
            {
                int tempInt = array[j];
                array[j] = array[j - 1];
                array[j - 1] = tempInt;
            }
        }
        Console.WriteLine(String.Join(" ", array));
    }
}

