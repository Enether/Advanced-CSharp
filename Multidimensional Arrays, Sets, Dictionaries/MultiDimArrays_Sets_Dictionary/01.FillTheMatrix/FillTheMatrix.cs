using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillTheMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the first dimension:");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the size of the second dimension:");
        int cols = int.Parse(Console.ReadLine());
        Console.WriteLine("Write A for Pattern A or B for Pattern B:");
        Repeat:
        char choice;
        char.TryParse(Console.ReadLine(), out choice);

        int[,] matrix = new int[rows, cols];
        int addThis = 1;
        if(choice == 'A' || choice == 'a')
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    matrix[col, row] = addThis++;
                }
            }
        }
        else if(choice == 'B' || choice == 'b')
        {
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0) NormalAddition(ref matrix, row, cols, ref addThis);
                else ReverseAddition(ref matrix, row, cols, ref addThis);
            }
        }
        else
        {
            Console.WriteLine("Invalid parameter");
            goto Repeat;
        }
        Console.ReadKey();
    }
    static void NormalAddition(ref int[,] matrix, int row, int cols, ref int addThis)
    {
        for (int col = 0; col < cols; col++)
        {
            matrix[col, row] = addThis++;
        }
    }
    static void ReverseAddition(ref int[,] matrix, int row, int cols, ref int addThis)
    {
        for (int col = cols-1; col >=  0; col--)
        {
            matrix[col, row] = addThis++;
        }
    }
}

