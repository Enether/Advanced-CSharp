using System;
using System.Linq;


class MaximalSum
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int firstDim = size[0];
        int secondDim = size[1];
        int[,] matrix = new int[firstDim, secondDim];

        FillMatrix(ref matrix, firstDim, secondDim);
        FindAndPrintBestSquare(matrix);
    }
    static void FillMatrix(ref int[,] matrix, int firstDim, int secondDim)
    {
        for (int i = 0; i < firstDim; i++)
        {
            int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < secondDim; j++)
            {
                matrix[i, j] = currentRow[j]; // loops through and assigns the input
            }
        }
    }
    static void FindAndPrintBestSquare(int[,] matrix)
    {
        int maxSum = int.MinValue;
        int sum = 0;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if ((col != 0 && col != matrix.GetLength(1) - 1) && (row != 0 && row != matrix.GetLength(0) - 1)) // checks if it can make a 3x3 square
                {
                    sum +=
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col - 1] + // middle row
                        matrix[row - 1, col] + matrix[row - 1, col + 1] + matrix[row - 1, col - 1] + // top row
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col - 1]; // bottom row
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                    sum = 0; // resets it, this is crucial
                }
            }
        }
        PrintSquare(matrix, maxSum, bestRow, bestCol);
    }
    static void PrintSquare(int[,] matrix, int maxSum, int row, int col)
    {
        Console.WriteLine(maxSum);
        Console.WriteLine("{0} {1} {2}", matrix[row - 1, col - 1], matrix[row - 1, col], matrix[row - 1, col + 1]);
        Console.WriteLine("{0} {1} {2}", matrix[row, col - 1], matrix[row, col], matrix[row, col + 1]);
        Console.WriteLine("{0} {1} {2}", matrix[row + 1, col - 1], matrix[row + 1, col], matrix[row + 1, col + 1]);
    }
}

