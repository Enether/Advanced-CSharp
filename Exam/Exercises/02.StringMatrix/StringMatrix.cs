using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StringMatrix
{
    static void Main()
    {
        string command = Console.ReadLine();
        int degrees = GetDegrees(command);
        List<string> inputLines = new List<string>();
        int longestLine = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
                break;

            inputLines.Add(input);
            if (longestLine < input.Length)
                longestLine = input.Length;
        }

        char[,] matrix = ConvertToMatrix(inputLines, longestLine);

        switch (degrees)
        {
            case 0:
                PrintMatrix(matrix);
                break;
            case 90:
                PrintMatrix(RotateMatrix(matrix));
                break;
            case 180:
                PrintMatrix(RotateMatrix(RotateMatrix(matrix)));
                break;
            case 270:
                PrintMatrix(RotateMatrix(RotateMatrix(RotateMatrix(matrix))));
                break;
        }
    }
    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    static char[,] RotateMatrix(char[,] matrix)
    {
        char[,] ret = new char[matrix.GetLength(1), matrix.GetLength(0)];
        //Rotate 90 degrees
        for (int row = matrix.GetLength(0) - 1, retCol = 0; row >= 0; row--, retCol++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                ret[col,retCol] = matrix[row,col];
            }
        }
        return ret;
    }
    static char[,] ConvertToMatrix(List<string> inputLines, int longestLine)
    {
        char[,] textMatrix = new char[inputLines.Count, longestLine];

        for (int i = 0; i < inputLines.Count; i++)
        {
            for (int j = 0; j < longestLine; j++)
            {
                if (j < inputLines[i].Length)
                    textMatrix[i, j] = inputLines[i][j];
                else
                    textMatrix[i, j] = ' ';
            }
        }

        return textMatrix;
    }
    static int GetDegrees(string command)
    {        
        int degrees = int.Parse(Regex.Match(command, @"Rotate\((\d*)\)").Groups[1].Value);

        int degree = 0;

        if (degrees % 360 == 0)
            degree = 0;
        else
        {
            for (int i = 1; i < 4; i++)
            {
                degrees -= 90;
                if (degrees % 360 == 0)
                {
                    degree = i * 90;
                    break;
                }
            }
        }

        return degree;
      
    }
}

