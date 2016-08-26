using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Exercise
    {
        static void Main(string[] args)
        {
            int[,] firstMatrix = { 
                    { 2, 3 }, 
                    { 1, 5 }, 
                    { 1, 5 }
                };
            int[,] secondMatrix = { 
                    { 2, 3 }, 
                    { 1, 5 } 
                };

            if(firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
            {
                int[,] newMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
                
                for (int col = 0; col < firstMatrix.GetLength(0); col++)
                {                  
                    for (int row = 0; row < secondMatrix.GetLength(1); row++)
                    {
                        newMatrix[col, row] = firstMatrix[col, row] * secondMatrix[row, col] + firstMatrix[col, row + 1] * secondMatrix[row + 1, col];
                    }
                }
            }
        }
        static void Te(int[,] te, int[,] tee, int col, int row)
        {

        }
    }
}
