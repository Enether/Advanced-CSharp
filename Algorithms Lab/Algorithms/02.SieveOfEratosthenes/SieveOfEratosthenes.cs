using System;
using System.Collections.Generic;
using System.Linq;

class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        IEnumerable<int> numbers = Enumerable.Range(0, n+1);
        List<int> list = numbers.ToList();
        int p = 1;

        for (int i = 0; i < list.Count(); i++)
        {
            if(list[i] > p)
            {
                p = list[i];
                for (int j = p; j * p <= n; j++)
                {
                    list[j * p] = 0;
                }
            }
        }

        list.RemoveRange(0, 2);
        list.RemoveAll(x => x == 0);
        Console.WriteLine(string.Join(", ", list));

    }
}

