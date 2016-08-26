using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int[][] JArray1 = new int[n][];
            int[][] JArray2 = new int[n][];
            char[] pssst = new char[] { ' ' };
            for (int i = 0, k = 0; i < n*2; i++, k++)
            {
                if(i < n)
                {
                    JArray1[k] = Console.ReadLine().Split(pssst, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                }
                else if(i >= n)
                {
                    JArray2[k] = Console.ReadLine().Split(pssst, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                }
                if (k == n-1) k = -1;
            }

            int length = JArray1[0].Length + JArray2[0].Length;
            bool doTheyFit = false;

            //check if they fit
            for (int i = 1; i < n; i++)
            {
                if (JArray1[i].Length + JArray2[i].Length == length) doTheyFit = true;
                else
                {
                    doTheyFit = false;
                    break;
                }
            }

            if (doTheyFit)
            {
                
                for (int i = 0; i < n; i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < JArray1[i].Length; j++)
                    {
                        Console.Write(JArray1[i][j] + ", ");
                    }
                    for (int j = JArray2[i].Length-1; j >= 0; j--)
                    {
                        if(j == 0)
                        {
                            Console.Write(JArray2[i][j]);
                        }
                        else
                        {
                            Console.Write(JArray2[i][j] + ", ");
                        }       
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
            }
            else
            {
                int numberOfCells = 0;
                for (int i = 0; i < n; i++)
                {
                    numberOfCells += JArray1[i].Length + JArray2[i].Length;
                }
                Console.WriteLine("The total number of cells is: {0}", numberOfCells);
            }
        }
    }
}
