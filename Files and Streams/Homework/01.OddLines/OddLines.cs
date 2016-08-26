using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        string path = @"..\..\TVDeal.txt";
        int count = 0;
        using(StreamReader sr = new StreamReader(path))
        {
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                    break;
                if(count % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                count++;
                
            }
        }
    }
}

