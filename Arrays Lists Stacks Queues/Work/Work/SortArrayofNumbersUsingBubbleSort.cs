using System;
using System.Linq;

class SortArrayofNumbersUsingBubbleSort
{
    static void Main()
    {
        int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(String.Join(" ", BubbleSort(numArray)));
    }
    public static int[] BubbleSort(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < array.Length; j++)
            {
                if (j == i) break;

                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        return array;
    }
}

