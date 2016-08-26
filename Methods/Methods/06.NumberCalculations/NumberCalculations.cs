using System;
using System.Collections.Generic;
using System.Linq;


class NumberCalculations
{
    static void Main()
    {
        List<int> intList = new List<int>{ 1, 2, 55 };
        List<double> doubleList = new List<double> { 1.5, 2.5, 3.5 };
        List<decimal> decimalList = new List<decimal> { 3.44513M, 54.1235266753M, 4.513414134M };
        Console.WriteLine("{0} {1} {2:#.##} {3} {4}", FindMaximum(intList), FindMinimum(intList), FindAverage(intList), FindSum(intList), FindProduct(intList));
        Console.WriteLine("{0} {1} {2} {3} {4}", FindMaximum(doubleList), FindMinimum(doubleList), FindAverage(doubleList), FindSum(doubleList), FindProduct(doubleList));
        Console.WriteLine("{0} {1} {2} {3} {4}", FindMaximum(decimalList), FindMinimum(decimalList), FindAverage(decimalList), FindSum(decimalList), FindProduct(decimalList));
    }
    static int FindProduct(List<int> list)
    {
        int product = 1;
        list.ForEach(p => product *= p);
        return product;
    }
    static double FindProduct(List<double> list)
    {
        double product = 1;
        list.ForEach(p => product *= p);
        return product;
    }
    static decimal FindProduct(List<decimal> list)
    {
        decimal product = 1;
        list.ForEach(p => product *= p);
        return product;
    }
    static int FindSum(List<int> list)
    {
        int sum = 0;
        list.ForEach(p => sum += p);
        return sum;
    }
    static double FindSum(List<double> list)
    {
        double sum = 0;
        list.ForEach(p => sum += p);
        return sum;
    }
    static decimal FindSum(List<decimal> list)
    {
        decimal sum = 0;
        list.ForEach(p => sum += p);
        return sum;
    }
    static double FindAverage(List<int> list)
    {
        double average = 0;
        foreach (int number in list)
        {
            average += number;
        }
        average /= list.Count();
        return average;
    }
    static double FindAverage(List<double> list)
    {
        double average = 0;
        foreach (double number in list)
        {
            average += number;
        }
        average /= list.Count();
        return average;
    }
    static decimal FindAverage(List<decimal> list)
    {
        decimal average = 0M;
        foreach (decimal number in list)
        {
            average += number;
        }
        average /= list.Count();
        return average;
    }
    static int FindMaximum(List<int> list)
    {
        int maximum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (maximum < list[i]) maximum = list[i];
        }
        return maximum;
    }
    static double FindMaximum(List<double> list)
    {
        double maximum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (maximum < list[i]) maximum = list[i];
        }
        return maximum;
    }
    static decimal FindMaximum(List<decimal> list)
    {
        decimal maximum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (maximum < list[i]) maximum = list[i];
        }
        return maximum;
    }
    static int FindMinimum(List<int> list)
    {
        int minimum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (minimum > list[i]) minimum = list[i];
        }
        return minimum;
    }
    static double FindMinimum(List<double> list)
    {
        double minimum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (minimum > list[i]) minimum = list[i];
        }
        return minimum;
    }
    static decimal FindMinimum(List<decimal> list)
    {
        decimal minimum = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            if (minimum > list[i]) minimum = list[i];
        }
        return minimum;
    }
}

