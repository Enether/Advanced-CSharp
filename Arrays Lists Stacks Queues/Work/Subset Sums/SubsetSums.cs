using System;
using System.Collections.Generic;
using System.Linq;

// the whole program, with the modifications for the sorted program commented out
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        arr = arr.Distinct().ToArray();
        int subsets = 1 << arr.Length;
        bool isRun = false;
        
        List<List<int>> twoDArray = new List<List<int>>();

        for (int i = 0; i < subsets; i++)
        {
            int pos = arr.Length - 1;
            int bitmask = i;
            List<int> tempList = new List<int>();
            int pst = 0;
            while (bitmask > 0)
            {
                
                if((bitmask & 1) == 1)
                {
                    tempList.Add(arr[pos]);
                   // twoDArray[i, pst] = arr[pos];
                    pst++;
                }
                bitmask >>= 1;
                pos--;
            }
            twoDArray.Add(tempList);
        }
        int[][] arrays = twoDArray.Select(a => a.ToArray()).ToArray();
        //for (int i = 0; i < arrays.Length; i++)
        //{
        //    Array.Sort(arrays[i]);
        //}
        //Array.Sort(arrays, (x, y) => x.Length.CompareTo(y.Length));
        for (int i = 0; i < arrays.Length; i++)
        {
            int sum = 0;
            foreach (int number in arrays[i])
            {
                sum += number;
                 
            }
            
            if(sum == n && sum != 0)
            {
                //Array.Sort(arrays[i]);
                isRun = true;
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] +" ");
                    if(!(j == arrays[i].Length - 1))
                    {
                        Console.Write("+ ");
                    }
                }
                Console.Write("= {0}", n);
                Console.WriteLine();
            }
        }
        if (!isRun) Console.WriteLine("No matching subsets.");

    }
}

