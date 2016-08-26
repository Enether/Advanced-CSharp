using System;
class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }
    static bool IsLargerThanNeighbours(int[] numbers, int index)
    {
        bool result = false;

        switch (FindIndexPosition(numbers.Length, index))
        {
            case "middle":
                if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1]) result = true;
                break;
            case "end":
                if (numbers[index] > numbers[index - 1]) result = true;
                break;
            case "start":
                if (numbers[index] > numbers[index + 1]) result = true;
                break;
        }
        return result;
    }
    static string FindIndexPosition(int length, int index)
    {
        string position = "";

        if(index > 0 && index < length - 1) position = "middle";

        else if(index == length - 1) position = "end";

        else if(index == 0) position = "start";

        return position;
    }
}

