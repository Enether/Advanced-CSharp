using System;
using System.Linq;
using System.Collections.Generic; 

class SortArrayOfNumbersUsingSelectionShort
{
    static void Main()
    {
        int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        List<int> endList = new List<int>();
        int CurrentSmallestNumber = 0;
        int BiggestNumberinList = 0;
        for (int i = 0; i < numbersArray.Length; i++)
        {
            CurrentSmallestNumber = numbersArray[i];
            for (int j = i; j < numbersArray.Length; j++)
            {                
                if (CurrentSmallestNumber >= numbersArray[j])
                {
                    CurrentSmallestNumber = numbersArray[j];
                }                
            }
            numbersArray[Array.LastIndexOf(numbersArray, CurrentSmallestNumber)] = numbersArray[i];
            numbersArray[i] = CurrentSmallestNumber;
            endList.Add(CurrentSmallestNumber);
            BiggestNumberinList = endList.Max();
        }
        Console.WriteLine(string.Join(" ", endList.Select(p => p.ToString())));
    }
}

