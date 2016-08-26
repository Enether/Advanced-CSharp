using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargestRectangle
{
    static void Main()
    {
        // awful awful awful
        string[][] matrix = new string[20][];
        string input = Console.ReadLine();
        int index = 0;
        while (input != "END")
        {
            matrix[index] = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            input = Console.ReadLine();
            index++;
        }
        int firstHeightIndex = 0; // [i][this]
        int heightLength = 1;
        int lastHeightIndex = 0;

        int leftWidthLength = 1;
        int lastLeftWidthIndex = 0;

        int bottomHeightLength = 1;
        int lastBottomHeightIndex = 0;

        int rightWidthLength = 1;
        int lastRightWidthIndex = 0;
        bool searching = false;
        for (int i = 0; i < index; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == "a" && searching == false)
                {
                    firstHeightIndex = j;
                    searching = true;
                }
                else if (matrix[i][j] == "a")
                {
                    heightLength++;
                }
                else if (searching == true) 
                {
                    lastHeightIndex = j - 1;
                    searching = false;
                    for (int k = i; k < index; k++)
                    {
                        if (matrix[k][firstHeightIndex] == "a")
                        {
                            leftWidthLength++;                         
                        }
                        else
                        {
                            lastLeftWidthIndex = k - 1;
                        }
                    }
                    for (int k = firstHeightIndex; k < matrix[lastLeftWidthIndex].Length; k++)
                    {
                        if(matrix[lastLeftWidthIndex][k] == "a")
                        {
                            bottomHeightLength++;
                        }
                        else
                        {
                            lastBottomHeightIndex = k - 1;
                        }
                    }
                    for (int k = lastLeftWidthIndex; k >= i; k--)
                    {
                        if(matrix[k][lastBottomHeightIndex] == "a")
                        {
                            rightWidthLength++;
                        }
                        else
                        {
                            lastRightWidthIndex = k - 1;
                        }
                    }

                }

            }
            searching = false;
        }
    }
}

