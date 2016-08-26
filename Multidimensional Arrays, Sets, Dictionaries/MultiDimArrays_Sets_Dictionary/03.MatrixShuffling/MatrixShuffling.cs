using System;
using System.Linq;
class MatrixShuffling
{
    static void Main(string[] args)
    {
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());

        string[,] matrix = new string[row, col];
        ReadMatrix(matrix, row, col);

        while (true)
        {
            string[] command = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (ShouldRun(command) == false) break;
            else matrix = RunCommand(command, matrix);
        }
    }

    static string[,] ReadMatrix(string[,] matrix, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
        return matrix;
    }
    static bool ShouldRun(string[] command)
    {
        bool isRunning = true;

        if (command.Contains("END"))
            isRunning = false;

        return isRunning;
    }
    static string[,] RunCommand(string[] command, string[,] matrix)
    {

        if (command.Length == 5 && command.Contains("swap")) // checks if the parameters are valid
        {
            int x1 = int.Parse(command[1]);
            int y1 = int.Parse(command[2]);
            int x2 = int.Parse(command[3]);
            int y2 = int.Parse(command[4]);
            if (matrix.GetLength(0) > x1 && matrix.GetLength(0) > x2 && matrix.GetLength(1) > y1 && matrix.GetLength(1) > y2) // further checks if the parameters are valid
            {
                string temp = matrix[x1, y1];
                matrix[x1, y1] = matrix[x2, y2];
                matrix[x2, y2] = temp;

                PrintMatrix(matrix);
            }
            else { Console.WriteLine("Invalid input!"); }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        return matrix;
    }
    static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

