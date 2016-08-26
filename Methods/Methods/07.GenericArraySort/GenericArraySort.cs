using System;
using System.Collections.Generic;
using System.Linq;

class GenericArraySort
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates =
        {
            new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1)
        };
        SortArray(numbers);
        SortArray(strings);
        SortArray(dates);
    }
    static void SortArray<T>(T[] arr) where T : IComparable
    {
        List<T> array = new List<T>();
        foreach (var item in arr)
        {
            array.Add(item);
        }
        
        // bubble sort
        for (int i = array.Count() - 1; i >= 0; i--)
        {
            for (int j = 0; j < array.Count(); j++)
            {
                if (j == i) break;

                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    T temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        Console.WriteLine(string.Join(", ", array));
    }
}

