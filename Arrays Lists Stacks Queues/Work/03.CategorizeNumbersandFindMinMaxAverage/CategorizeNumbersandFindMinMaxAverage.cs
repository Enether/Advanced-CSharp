using System;
using System.Collections.Generic;
using System.Linq;


class CategorizeNumbersandFindMinMaxAverage
{
    static void Main()
    {
        List<double> startingList = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

        List<int> roundList = new List<int>();
        List<double> notroundList = new List<double>();

        foreach (var item in startingList)
        {
            if(item == Math.Round(item))
            {
                roundList.Add(Convert.ToInt32(item));
            }
            else
            {
                notroundList.Add(item);
            }
        }

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}"
            , string.Join(", ", notroundList), notroundList.Min(), notroundList.Max(), notroundList.Sum(), notroundList.Average());

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}"
            , string.Join(", ", roundList), roundList.Min(), roundList.Max(), roundList.Sum(), roundList.Average());

    }
}

