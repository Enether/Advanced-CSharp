using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06.X_Removal
{
    class XRemoval
    {
        static void Main()
        {
            var inputLines = ReceiveInput();

            char[][] textMatrixLower = ConvertToMatrixLower(inputLines);
            char[][] textMatrixNormal = ConvertToMatrixAsync(inputLines).Result;

            HashSet<Tuple<int, int>> indexesToRemove = FindIndexesToRemove(textMatrixLower);

            PrintMatrix(textMatrixNormal, indexesToRemove);
        }
        static void PrintMatrix(char[][] textMatrix, HashSet<Tuple<int, int>> indexesToRemove)
        {
            for (int rows = 0; rows < textMatrix.Length; rows++)
            {
                for (int cols = 0; cols < textMatrix[rows].Length; cols++)
                {
                    Tuple<int, int> test = new Tuple<int, int>(rows, cols);
                    if (!indexesToRemove.Contains(test))
                        Console.Write(textMatrix[rows][cols]);
                }
                Console.WriteLine();
            }
        }
        static HashSet<Tuple<int, int>> FindIndexesToRemove(char[][] textMatrixLower)
        {
            HashSet<Tuple<int, int>> indexesToRemove = new HashSet<Tuple<int, int>>();

            for (int row = 1; row < textMatrixLower.Length - 1; row++)
            {
                for (int col = 1; col < textMatrixLower[row].Length; col++)
                {
                    char symbol = textMatrixLower[row][col];
                    if (textMatrixLower[row - 1].Length > col + 1 && textMatrixLower[row + 1].Length > col + 1) // check to not go out of bounds in the upper and lower array
                    {
                        if (textMatrixLower[row - 1][col - 1] == symbol &&
                            textMatrixLower[row - 1][col + 1] == symbol &&
                            textMatrixLower[row + 1][col - 1] == symbol &&
                            textMatrixLower[row + 1][col + 1] == symbol)
                        {
                            indexesToRemove.Add(new Tuple<int, int>(row, col));
                            indexesToRemove.Add(new Tuple<int, int>(row - 1, col - 1));
                            indexesToRemove.Add(new Tuple<int, int>(row - 1, col + 1));
                            indexesToRemove.Add(new Tuple<int, int>(row + 1, col - 1));
                            indexesToRemove.Add(new Tuple<int, int>(row + 1, col + 1));
                        }
                    }
                }
            }

            return indexesToRemove;
        }
        static async Task<char[][]> ConvertToMatrixAsync(List<string> inputLines)
        {
            Task<char[][]> task = Task.Run(() =>
            {
                char[][] textMatrix = new char[inputLines.Count()][];
                for (int row = 0; row < textMatrix.GetLength(0); row++)
                {
                    textMatrix[row] = inputLines[row].ToCharArray();
                }
                return textMatrix;
            });

            return await task;
        }
        static char[][] ConvertToMatrixLower(List<string> inputLines)
        {
            char[][] textMatrix = new char[inputLines.Count()][];
            for (int row = 0; row < textMatrix.GetLength(0); row++)
            {
                textMatrix[row] = inputLines[row].ToLower().ToCharArray();
            }
            return textMatrix;
        }
        static List<string> ReceiveInput()
        {
            List<string> inputLines = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                    break;

                inputLines.Add(input);
            }
            return inputLines;
        }
    }
}
