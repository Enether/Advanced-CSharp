using System;
using System.Linq;

class LinearAndBinarySearch
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int element = int.Parse(Console.ReadLine());
        Console.WriteLine(BinarySearch(array,element));
    }
    static int BinarySearch(int[] array, int element)
    {
        int index = -1;
        int length = array.Length;
        for (int i = 0; i < length; i++)
        {
            int[] findIndex = new int[length-i];
            for (int j = i, k=0; j < length; j++, k++)
            {
                findIndex[k] = j;
            }
            int middleIndex = findIndex[(length - i - 1) / 2];
            if (array[middleIndex] > element)
            {
                length = middleIndex;
            }
            else if(array[middleIndex] < element)
            {
                i = middleIndex;
            }
            else
            {
                index = middleIndex;
                break;
            }
        }
        for (int i = index; i >= 0; i--)
        {
            if (array[i] == element)
                index = i;
            else
                break;
        }

        return index;
    }
    static int  LinearSearch(int[] array, int element)
    {
        int index = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] == element)
            {
                index = i;
                break;
            }
        }
        return index;
    }
}

