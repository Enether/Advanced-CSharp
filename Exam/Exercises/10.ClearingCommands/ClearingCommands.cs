using System;
using System.Collections.Generic;
using System.Security;

class ClearingCommands
{
    static void Main()
    {
        char[][] matrix = FillMatrix(ReceiveInput());
        char a = ' ';

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                a = matrix[row][col];

                switch (matrix[row][col])
                {
                    case '>':
                        for (int coll = col+1; coll < matrix[row].Length; coll++)
                        {
                            a = matrix[row][coll];
                            if (a == '>' || a == '<' || a == 'v' || a == '^')// checks if it's a command
                                break;
                            else
                                matrix[row][coll] = ' ';
                        }
                        break;
                    case '<':
                        for (int coll = col-1; coll >= 0; coll--)
                        {
                            a = matrix[row][coll];
                            if (a == '>' || a == '<' || a == 'v' || a == '^')// checks if it's a command
                                break;
                            else
                                matrix[row][coll] = ' ';
                        }
                        break;
                    case '^':
                        for (int roww = row-1; roww >= 0; roww--)
                        {
                            if(matrix[roww].Length > col)
                            {
                                a = matrix[roww][col];
                                if (a == '>' || a == '<' || a == 'v' || a == '^')// checks if it's a command
                                    break;
                                else
                                    matrix[roww][col] = ' ';
                            }
                        }
                        break;
                    case 'v':
                        for (int roww = row+1; roww < matrix.Length; roww++)
                        {
                            if (matrix[roww].Length > col)
                            {
                                a = matrix[roww][col];
                                if (a == '>' || a == '<' || a == 'v' || a == '^') // checks if it's a command
                                    break;
                                else
                                    matrix[roww][col] = ' ';
                            }
                        }
                        break;
                }
            }
        }

        PrintMatrix(matrix);
    }
    static void PrintMatrix(char[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            Console.Write("<p>");
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(SecurityElement.Escape(matrix[row][col].ToString()));
            }
            Console.WriteLine("</p>");
        }
    }
    static char[][] FillMatrix(List<string> inputLines)
    {
        char[][] matrix = new char[inputLines.Count][];

        for (int i = 0; i < inputLines.Count; i++)
        {
            matrix[i] = inputLines[i].ToCharArray();
        }

        return matrix;
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

