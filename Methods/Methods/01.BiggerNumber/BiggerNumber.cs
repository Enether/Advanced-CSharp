using System;
class Program
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        int maxNumber = GetMax(firstNumber, secondNumber);
        Console.WriteLine(maxNumber);
    }
    static int GetMax(int firstN, int secondN)
    {
        int max = 0;
        if(firstN >= secondN)
        {
            max = firstN;
        }
        else
        {
            max = secondN;
        }
        return max;
    }
}

