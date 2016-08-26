using System;
using System.Text;
using System.Text.RegularExpressions;

class MatrixShuffle
{
    public enum Direction { Up, Down, Left, Right};
    static void Main()
    {
        // 100/100 god dammit!

        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        char[,] spiralMatrix = FillMatrix(text, lineLength);

        string result = ReadMatrix(spiralMatrix, lineLength);

        if (IsPalindrome(result))
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
        }
    }
    static bool IsPalindrome(string result)
    {
        bool isPalindrome = false;
        string resultWithoutSpace = Regex.Replace(result, @"[^A-Za-z]*", ""); // removes all whitespaces so we compare the strings

        if (resultWithoutSpace.ToLower() == ReverseString(resultWithoutSpace).ToLower()) // checks if they're identical
            isPalindrome = true;

        return isPalindrome;
    }
    static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();

        Array.Reverse(arr);

        return new string(arr);
    }
    static string ReadMatrix(char[,] spiralMatrix, int lineLength)
    {
        StringBuilder whiteSquares = new StringBuilder();
        StringBuilder blackSquares = new StringBuilder();
        // read the matrix in a chessboard pattern
        for (int row = 0; row < lineLength; row++)
        {
            if (row % 2 == 0) // row starts with a white square
            {
                for (int col = 0; col < lineLength; col++)
                {
                    if (spiralMatrix[row, col] != 0)
                    {
                        if (col % 2 == 0) //it's a white square
                            whiteSquares.Append(spiralMatrix[row, col]);
                        else //it's a black square
                            blackSquares.Append(spiralMatrix[row, col]);
                    }
                }
            }
            else // row starts with a black square
            {
                for (int col = 0; col < lineLength; col++)
                {
                    if (spiralMatrix[row, col] != 0)
                    {
                        if (col % 2 == 0) // it's a black square
                            blackSquares.Append(spiralMatrix[row, col]);
                        else // it's a white square
                            whiteSquares.Append(spiralMatrix[row, col]);
                    }
                }
            }
        }

        whiteSquares.Append(blackSquares.ToString()); // join them together
        return whiteSquares.ToString();
    }
    static char[,] FillMatrix(string text, int lineLength)
    {
        char[,] spiralMatrix = new char[lineLength, lineLength];
        Direction direction = Direction.Right; // get's the default direction for the algorithm
        int textIndex = 0; // tracks at which position we are at the text
        int row = 0;
        int col = 0;
        int maxRotations = lineLength * lineLength;


        for (int i = 0; i < maxRotations; i++)
        {
            if (textIndex < text.Length && spiralMatrix[row, col] == 0) // checks that we don't write over a char and that we haven't written the whole text
            {
                spiralMatrix[row, col] = text[textIndex];
                textIndex++;
            }
            else if (spiralMatrix[row, col] == 0)
                spiralMatrix[row, col] = ' ';

            switch (direction)
            {
                case Direction.Right:
                    if (col + 1 >= lineLength || spiralMatrix[row, col + 1] != 0) // checks that we don't go out of bounds or we dont write over a char
                    {
                        direction = Direction.Down;
                        row++;
                    }
                    else
                        col++;

                    break;

                case Direction.Left:
                    if (col - 1 < 0 || spiralMatrix[row, col - 1] != 0)// checks that we don't go out of bounds or we dont write over a char
                    {
                        direction = Direction.Up;
                        row--;
                    }
                    else
                        col--;

                    break;

                case Direction.Down:
                    if (row + 1 >= lineLength || spiralMatrix[row + 1, col] != 0)// checks that we don't go out of bounds or we dont write over a char
                    {
                        direction = Direction.Left;
                        col--;
                    }
                    else
                        row++;

                    break;

                case Direction.Up:
                    if (row - 1 < 0 || spiralMatrix[row - 1, col] != 0)// checks that we don't go out of bounds or we dont write over a char
                    {
                        direction = Direction.Right;
                        col++;
                    }
                    else
                        row--;
                    break;
            }
        }
        return spiralMatrix;
    }
}

