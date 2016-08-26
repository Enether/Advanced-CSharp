using System;

class PrintingTriangle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        PrintTriangle(n);
    }
    static void PrintTriangle(int n)
    {
        // from 1 to n
        for (int i = 1; i <= n; i++)
        {
            PrintNumbers(i);
            Console.WriteLine();
        }
        // from n-1 to 1
        for (int i = n-1; i > 0; i--)
        {
            PrintNumbers(i);
            Console.WriteLine();
        }
    }
    static void PrintNumbers(int end)
    {
        for (int i = 1; i <= end; i++)
        {
            Console.Write("{0} ", i);
        }
    }
}

