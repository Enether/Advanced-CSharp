
using System;
using System.Linq;

public class ArraysMain
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Contains("stop"))
        {
            string line = command;
            int[] args = new int[2];
            string[] stringParams = line.Split(ArgumentsDelimiter);
            string action = stringParams[0];

            if (command.Contains("add") ||
                command.Contains("subtract") ||
                command.Contains("multiply"))
            {
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);

                PerformAction(ref array, action, args);
            }
            else
            {
                PerformAction(ref array, action);
            }

            PrintArray(array);

            command = Console.ReadLine();
        }
    }

    static void PerformAction(ref long[] array, string action, int[] args)
    {
       // long[] array = arr.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
        }
    }
    static void PerformAction(ref long[] array, string action)
    {

        switch (action)
        {
            case "lshift":
                ArrayShiftLeft(ref array);
                break;
            case "rshift":
                ArrayShiftRight(ref array);
                break;
        }
    }

    private static void ArrayShiftRight(ref long[] array)
    {
        long lastElement = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = lastElement;
    }

    private static void ArrayShiftLeft(ref long[] array)
    {
        long firstElement = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

