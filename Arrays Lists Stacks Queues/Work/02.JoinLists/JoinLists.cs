using System;
using System.Collections.Generic;
using System.Linq;


class JoinLists
{
    static void Main()
    {
        // process input
        List<string> templist = Console.ReadLine().Split(' ').ToList();
        List<int> firstList = new List<int>();
        foreach (var item in templist)
        {
            firstList.Add(int.Parse(item));
        }
        templist = Console.ReadLine().Split(' ').ToList();
        List<int> secondList = new List<int>();
        foreach (var item in templist)
        {
            secondList.Add(int.Parse(item));
        }

        List<int> newList = BubbleSort(Join(firstList, secondList));

        Console.WriteLine(string.Join(" ", newList));
    }
    public static List<int> Join(List<int> firstList,List<int> secondList)
    {
        List<int> newList = new List<int>();

        foreach (int number in firstList)
        {
            if(!newList.Contains(number)) newList.Add(number);
        }
        for (int i = 0; i < secondList.Count(); i++)
        {
            bool isRepeated = false;
            for (int j = 0; j < firstList.Count(); j++)
            {
                if (secondList[i] == firstList[j]) isRepeated = true;
            }
            if (!isRepeated) newList.Add(secondList[i]);
        }

        return newList;
    }
    public static List<int> BubbleSort(List<int> newList)
    {
        for (int i = newList.Count(); i >= 0; i--)
        {
            for (int j = 0; j < newList.Count(); j++)
            {
                if (j + 1 == i || i == 0) break;
                if(newList[j] > newList[j + 1])
                {
                    int temp = newList[j];
                    newList[j] = newList[j + 1];
                    newList[j + 1] = temp;
                }
            }
        }
        return newList;
    }
}

