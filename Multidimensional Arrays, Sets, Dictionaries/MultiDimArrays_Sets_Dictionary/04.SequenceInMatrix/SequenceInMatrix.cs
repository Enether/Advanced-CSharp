using System;
using System.Collections.Generic;
using System.Linq;


class SequenceInMatrix
{
    static void Main()
    {
        string[,] matrix =
        {
            {"s","qq","s"},
            {"pp","pp","s" },
            {"pp","qq","s" }
        };
        List<string> currentLongestSequence = new List<string>();
        List<string> longestSequence = new List<string>();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                // we need these temporary integers so we can continue the while loop
                int tempCol = col;
                int tempRow = row;

                currentLongestSequence.Add(matrix[row, col]); // adds the current element
                while(CheckNeighbours(matrix, ref tempRow, ref tempCol))
                {
                    currentLongestSequence.Add(matrix[row, col]);
                    
                }
                if (currentLongestSequence.Count() > longestSequence.Count()) // checks if it should update longest sequence
                {
                    longestSequence.Clear();
                    longestSequence = new List<string>(currentLongestSequence);
                }
                currentLongestSequence.Clear(); // clears the temporary list so it can fill it up again
            }
        }
        Console.WriteLine(string.Join(", ", longestSequence));

    }
    static bool CheckNeighbours(string[,] matrix, ref int row, ref int col)
    {
        bool foundNeighbour = false;
        if (row != (matrix.GetLength(0) - 1)) // checks bottom
        {
            if(matrix[row,col] == matrix[row + 1, col])
            {
                row += 1;
                foundNeighbour = true;
            }
        }
        if (col != (matrix.GetLength(1) - 1)) // checks side
        {
            if(matrix[row,col] == matrix[row, col + 1])
            {
                col += 1;
                foundNeighbour = true;
            }
        }
        if (row != (matrix.GetLength(0) - 1) && col != (matrix.GetLength(1) - 1)) // checks diagonal
        {
            if(matrix[row,col] == matrix[row + 1, col + 1])
            {
                row += 1;
                col += 1;
                foundNeighbour = true;
            }
        }
        return foundNeighbour;
    }
}

