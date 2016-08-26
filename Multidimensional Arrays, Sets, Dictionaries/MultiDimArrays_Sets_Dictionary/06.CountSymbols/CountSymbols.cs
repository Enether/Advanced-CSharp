using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        char[] array = Console.ReadLine().ToCharArray();
        HashSet<string> set = new HashSet<string>();
        Array.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            int count = 0;
            foreach (char a in array)
            {
                if (a == array[i]) count++;
            }
            string temp = array[i] + ": " + count + " time/s";
            set.Add(temp);
        }
        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
    }
}

