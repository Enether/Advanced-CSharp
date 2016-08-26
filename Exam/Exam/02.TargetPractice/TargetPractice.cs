using System;
using System.Linq;
using System.Text;

class TargetPractice
{
    static void Main()
    {
        //100/100 GOD DAMMIT !!
        int[] colAndRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int nRows = colAndRow[0];
        int mCols = colAndRow[1];

        string snakeString = Console.ReadLine();

        int[] impactRowColAndRadius = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();
        int impactRow = impactRowColAndRadius[0];
        int impactCol = impactRowColAndRadius[1];
        int impactRadius = impactRowColAndRadius[2];

        string stretchedSnakeString = StretchString(snakeString, nRows, mCols);

        char[,] matrix = SymbolsFallDown(
            ImpactMatrix(
            FillMatrix(stretchedSnakeString, nRows, mCols)
            , nRows, mCols, impactRow, impactCol, impactRadius)
            , nRows, mCols); // all the methods stacked on each other

        Print(matrix);
    }
    public static char[,] SymbolsFallDown(char[,] matrix, int nRows, int mCols)
    {
        for (int row = nRows - 1; row >= 0; row--) // starts from the last row and goes up
        {
            for (int col = 0; col < mCols; col++)
            {
                if (matrix[row, col] != ' ') // checks if selected character is not a whitespace
                {
                    //runs a loop down the rows to check for whitespaces
                    //makes our selected char fall down until it can't no more
                    for (int i = 1; i + row < nRows; i++)
                    {
                        if (matrix[row + i, col] == ' ')
                        {
                            matrix[row + i, col] = matrix[row + i - 1, col];
                            matrix[row + i - 1, col] = ' ';
                        }
                        else
                            break;
                    }
                }
            }
        }
        return matrix;
    }
    public static char[,] ImpactMatrix(char[,] matrix, int nRows, int mCols, int impactRow, int impactCol, int impactRadius)
    {
        for (int i = 0; i < nRows; i++)
        {
            double x = i - impactRow;
            for (int j = 0; j < mCols; j++)
            {
                double y = j - impactCol;
                double discriminant = Math.Sqrt((x * x) + (y * y));

                if (discriminant <= impactRadius)
                {
                    matrix[i, j] = ' ';
                }
            }
        }
        return matrix;
    }
    public static void Print(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    public static char[,] FillMatrix(string stretchedSnakeString, int nRows, int mCols)
    {
        char[,] matrix = new char[nRows, mCols];

        int left = 0;
        int textIndex = 0;
        for (int rows = nRows - 1; rows >= 0; rows--, left++)
        {
            if (left % 2 == 0)
            {
                for (int cols = mCols - 1; cols >= 0; cols--)
                {
                    matrix[rows, cols] = stretchedSnakeString[textIndex];
                    textIndex++;
                }
            }
            else
            {
                for (int cols = 0; cols < mCols; cols++)
                {
                    matrix[rows, cols] = stretchedSnakeString[textIndex];
                    textIndex++;
                }
            }
        }

        return matrix;
    }
    public static string StretchString(string snakeString, int n, int m)
    {
        int length = snakeString.Length;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i <= n*m; i+=length)
        {
            sb.Append(snakeString);
        }

        return sb.ToString();
    }
}

