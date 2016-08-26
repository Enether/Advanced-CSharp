using System;
using System.Collections.Generic;
using System.Linq;


class SequenceOfEqualStrings
{
    static void Main()
    {
        List<string> strList = Console.ReadLine().Split(' ').ToList();

        for (int i = 0; i < strList.Count(); i++)
        {
            for (int j = 0; j < strList.Count(); j++)
            {
                if (strList[i] == strList[j])
                {
                    Console.Write("{0} ", strList[i]);
                }
            }
            Console.WriteLine();
            i = strList.LastIndexOf(strList[i]);
        }
    }
}

