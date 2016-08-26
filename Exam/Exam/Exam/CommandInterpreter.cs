using System;
using System.Text.RegularExpressions;

class CommandInterpreter
{
    static void Main()
    {
        //85/100
        string inputLine = Console.ReadLine();

        inputLine = Regex.Replace(inputLine, @"\s+", " ");

        string[] stringArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
                break;

            if (command.StartsWith("rollLeft"))
            {
                Match match = Regex.Match(command, @"rollLeft (?<number>\d+)\s*(times)*");
                try
                {
                    int count = int.Parse(match.Groups["number"].Value);
                    if (count >= 0)
                    {
                        stringArray = ShiftNTimesLeft(stringArray, count);
                    }
                    else
                        Console.WriteLine("Invalid input parameters.");
                }
                catch (FormatException fe) { }

            }
            else if (command.StartsWith("rollRight"))
            {
                Match match = Regex.Match(command, @"rollRight (?<number>\d+)\s*(times)*");
                try
                {
                    int count = int.Parse(match.Groups["number"].Value);
                    if (count >= 0)
                    {
                        stringArray = ShiftNTimesRight(stringArray, count);
                    }
                    else
                        Console.WriteLine("Invalid input parameters.");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid input parameters.");
                }


            }
            else if (command.StartsWith("sort"))
            {
                Match match = Regex.Match(command, @"sort from (?<start>\d+) count (?<count>\d+)");
                try
                {
                    int count = int.Parse(match.Groups["count"].Value);
                    int startIndex = int.Parse(match.Groups["start"].Value);

                    if (startIndex >= 0 && startIndex < stringArray.Length && count >= 0 && count + startIndex <= stringArray.Length)
                    {
                        stringArray = SortArray(stringArray, count, startIndex);
                    }
                    else
                        Console.WriteLine("Invalid input parameters.");
                }
                catch (FormatException fe) { Console.WriteLine("Invalid input parameters."); }

            }
            else if (command.StartsWith("reverse"))
            {
                Match match = Regex.Match(command, @"reverse from (?<start>\d+) count (?<count>\d+)");
                try
                {
                    int count = int.Parse(match.Groups["count"].Value);
                    int startIndex = int.Parse(match.Groups["start"].Value);

                    if (startIndex >= 0 && startIndex < stringArray.Length && count >= 0 && count + startIndex <= stringArray.Length)
                    {
                        stringArray = ReverseArray(stringArray, count, startIndex);
                    }
                    else
                        Console.WriteLine("Invalid input parameters.");
                }
                catch (FormatException fe) { Console.WriteLine("Invalid input parameters."); }

            }
            else
                Console.WriteLine("Invalid input parameters.");
        }
        Console.WriteLine("[{0}]", string.Join(", ", stringArray));
    }
    public static string[] ReverseArray(string[] stringArray, int count, int startIndex)
    {
        string[] array = stringArray;
        string[] arrayToReverse = new string[count];

        for (int i = startIndex, j = 0; i < startIndex + count; i++, j++) // fill the array we are going to reverse
        {
            arrayToReverse[j] = array[i];
        }
        Array.Reverse(arrayToReverse);
        for (int i = startIndex, j = 0; i < startIndex + count; i++, j++)
        {
            array[i] = arrayToReverse[j];
        }
        return array;
    }
    public static string[] SortArray(string[] stringArray, int count, int startIndex)
    {
        string[] array = stringArray;
        string[] arrayToSort = new string[count];

        for (int i = startIndex, j = 0; i < startIndex + count; i++, j++)
        {
            arrayToSort[j] = array[i];
        }
        Array.Sort(arrayToSort);
        for (int i = startIndex, j = 0; i < startIndex + count; i++, j++)
        {
            array[i] = arrayToSort[j];
        }

        return array;
    }
    public static string[] ShiftNTimesLeft(string[] array, int numShifts)
    {
        int timesShifted = 0;
        if (numShifts % array.Length != 0)
        {
            numShifts %= array.Length;
            while (timesShifted < numShifts)
            {
                string temp = array[0];
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[array.Length - 1] = temp;
                timesShifted++;
            }
        }


        return array;
    }
    public static string[] ShiftNTimesRight(string[] array, int numShifts)
    {
        int timesShifted = 0;
        if (numShifts % array.Length != 0)
        {
            numShifts %= array.Length;
            while (timesShifted < numShifts)
            {
                string temp = array[array.Length - 1];
                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = temp;
                timesShifted++;
            }
        }


        return array;
    }
}
