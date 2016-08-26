using System;

class SnakeMatrix
{
    static void Main()
    {
        Console.Write("I want my matrix to be of size: ");
        int firstDim = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("I want my matrix to be of size: {0}x", firstDim);
        int secondDim = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("I want my matrix to be of size: {0}x{1}\n", firstDim, secondDim);

        int[,] matrix = new int[firstDim, secondDim];
        int n = 1;
        for (int row = 0; row < firstDim; row++)
        {
            if (row % 2 == 0) NormalGeneration(ref matrix, row, secondDim, ref n);
            else ReverseGeneration(ref matrix, row, secondDim, ref n);
        }
        Console.WriteLine("Done!");
    }
    static void NormalGeneration(ref int[,] matrix, int row, int secondDim, ref int n)
    {
        for (int col = 0; col < secondDim; col++)
        {
            matrix[row, col] = n;
            n++;
        }
    }
    static void ReverseGeneration(ref int[,] matrix, int row, int secondDim, ref int n)
    {
        for (int col = secondDim-1; col >= 0; col--)
        {
            matrix[row, col] = n;
            n++;
        }
    }
}

