using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LongestIncreasingSequence
{
    static void Main()
    {
        List<int> intList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int[,] te = new int[intList.Count(), intList.Count()];
        int firstDimension = 0;
        int secondDimension = 0;
        int biggestIndex = 0;
        int biggestSequence = 0;
        bool firstIter = true;
        for (int i = 0; i < intList.Count(); i++, firstDimension++)
        {
            te[firstDimension,secondDimension] = intList[i];
            Console.Write("{0} ", intList[i]);

            for (int j = i+1; j < intList.Count(); j++)
            {
                if(intList[i] < intList[j] && firstIter == true)
                {
                    secondDimension++;
                    te[firstDimension,secondDimension] = intList[j];
                    Console.Write("{0} ", intList[j]);
                    firstIter = false;
                }
                else if(intList[j-1] < intList[j] && firstIter == false)
                {
                    secondDimension++;
                    te[firstDimension,secondDimension] = intList[j];
                    Console.Write("{0} ", intList[j]);
                }
                else
                {
                    break;
                }
            } 
                      
            int checkIfStuck = intList.IndexOf(te[firstDimension, secondDimension]);
            if(checkIfStuck < i)
            {
                i++;
                Console.WriteLine();
                Console.Write("{0} ", intList[i]);               
            }
            else
            {
                i = intList.IndexOf(te[firstDimension, secondDimension]);
            }

            if (secondDimension > biggestSequence)
            {
                biggestSequence = secondDimension;
                biggestIndex = firstDimension;
            }
            firstIter = true;
            secondDimension = 0;
            Console.WriteLine();
        }
        Console.Write("Longest: ");
        for (int i = 0; i <= biggestSequence; i++)
        {
            Console.Write("{0} ", te[biggestIndex,i]);
        }
        Console.WriteLine();
    }
}

