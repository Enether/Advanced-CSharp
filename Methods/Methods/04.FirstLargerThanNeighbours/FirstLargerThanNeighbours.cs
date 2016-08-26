using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }
    static int GetIndexOfFirstElementLargerThanNeighbours(int[] array)
    {
        int index = -1;
        for (int i = 0; i < array.Length; i++)
        {
            index = GetTheIndex(array, i);
            if (index != -1) break;
        }
        return index;
    }

    private static int GetTheIndex(int[] array, int index)
    {
        switch (FindIndexPosition(array.Length, index))
        {
            case "middle":
                if (array[index] > array[index - 1] && array[index] > array[index + 1]) return index;
                break;
            case "end":
                if (array[index] > array[index - 1]) return index;
                break;
            case "start":
                if (array[index] > array[index + 1]) return index;
                break;
        }
        return -1;
    }

    static string FindIndexPosition(int length, int index)
    {
        string position = "";

        if (index > 0 && index < length - 1) position = "middle";

        else if (index == length - 1) position = "end";

        else if (index == 0) position = "start";

        return position;
    }
}

