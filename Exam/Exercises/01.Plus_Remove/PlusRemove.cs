using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class PlusRemove
{
    static void Main()
    {
        List<string> inputLines = ReceiveInput();
        char[][] textMatrixLowerCase = ConvertToMatrixLower(inputLines).Result;
        char[][] textMatrix = ConvertToMatrix(inputLines);

        HashSet<Tuple<int, int>> removedShapesIndexes = new HashSet<Tuple<int, int>>();

        for (int row = 0; row < textMatrixLowerCase.Length; row++)
        {
            bool notOnFirstOrLastRow = row != 0 && row != textMatrixLowerCase.Length - 1;
            for (int col = 0; col < textMatrixLowerCase[row].Length; col++)
            {
                bool notOnFirstOrLastCol = col != 0 && col != textMatrixLowerCase[row].Length - 1;
                if (notOnFirstOrLastRow && notOnFirstOrLastCol) // checks that we're not on the last or first row/col so as to not have any errors
                {
                    char symbol = textMatrixLowerCase[row][col];

                    if(textMatrixLowerCase[row-1].Length > col && textMatrixLowerCase[row+1].Length > col)
                    {
                        if (textMatrixLowerCase[row][col - 1] == symbol
                       && textMatrixLowerCase[row][col + 1] == symbol
                       && textMatrixLowerCase[row - 1][col] == symbol
                       && textMatrixLowerCase[row + 1][col] == symbol
                       )
                        {
                            removedShapesIndexes.Add(new Tuple<int, int>(row, col));
                            removedShapesIndexes.Add(new Tuple<int, int>(row, col - 1));
                            removedShapesIndexes.Add(new Tuple<int, int>(row, col + 1));
                            removedShapesIndexes.Add(new Tuple<int, int>(row - 1, col));
                            removedShapesIndexes.Add(new Tuple<int, int>(row + 1, col));
                        }
                    }                   
                }
            }
        }

        for (int row = 0; row < textMatrix.Length; row++)
        {
            for (int col = 0; col < textMatrix[row].Length; col++)
            {
                Tuple<int, int> removeIndexes = new Tuple<int, int>(row, col);
                if (!removedShapesIndexes.Contains(removeIndexes))
                    Console.Write(textMatrix[row][col]);
            }
            Console.WriteLine();
        }
    }
    static List<string> ReceiveInput()
    {
        // create a list and then convert it to a char matrix array
        List<string> inputLines = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            inputLines.Add(input);
        }

        return inputLines;       
    }
    static async Task<char[][]> ConvertToMatrixLower(List<string> inputLines)
    {
        Task<char[][]> matrix = Task.Run(() =>
        {
            char[][] textMatrix = new char[inputLines.Count()][];
            for (int i = 0; i < textMatrix.Length; i++)
            {
                textMatrix[i] = inputLines[i].ToLower().ToCharArray();
            }
            return textMatrix;
        });

        char[][] m = await matrix;
        return m;
    }
    static char[][] ConvertToMatrix(List<string> inputLines)
    {
        char[][] textMatrix = new char[inputLines.Count()][];
        for (int i = 0; i < textMatrix.Length; i++)
        {
            textMatrix[i] = inputLines[i].ToCharArray();
        }
        return textMatrix;
    }
}

