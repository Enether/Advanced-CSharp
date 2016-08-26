using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class TextGravity
{
    static void Main()
    {
        // Originally got 62/100, had to look at the test to reconfigure the rowLength calculation.
        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        text = ConvertWhitespaceToSpacesRegex(text);
        int rowLength = 0;
        if(text.Length % lineLength == 0)
        {
            rowLength = text.Length / lineLength;
        }
        else
        {
            rowLength = (text.Length / lineLength) + 1;
        }
       

        char[,] gravityMatrix = new char[rowLength, lineLength];
        gravityMatrix = FillMatrix(gravityMatrix, text);

        for (int row = gravityMatrix.GetLength(0)-1; row >= 0; row--) // starts from the last row and goes up
        {
            for (int col = 0; col < gravityMatrix.GetLength(1); col++)
            {
                if(gravityMatrix[row,col] != ' ') // checks if selected character is not a whitespace
                {
                    //runs a loop down the rows to check for whitespaces
                    //makes our selected char fall down until it can't no more
                    for (int i = 1; i+row < gravityMatrix.GetLength(0); i++) 
                    {
                        if (gravityMatrix[row + i, col] == ' ')
                        {
                            gravityMatrix[row + i, col] = gravityMatrix[row + i - 1, col];
                            gravityMatrix[row + i - 1, col] = ' ';
                        }
                        else
                            break;
                    }
                }
            }
        }

        Console.Write("<table>");
        for (int row = 0; row < gravityMatrix.GetLength(0); row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < gravityMatrix.GetLength(1); col++)
            {
                string character = gravityMatrix[row, col].ToString();
                if(character.Any(ch => !Char.IsLetterOrDigit(ch)))
                {
                    Console.Write("<td>{0}</td>", SecurityElement.Escape(character));
                }
                else
                {
                    Console.Write("<td>{0}</td>", character);
                }
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }

    static char[,] FillMatrix(char[,] gravityMatrix, string text)
    {
        int textIndex = 0;
        for (int row = 0; row < gravityMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < gravityMatrix.GetLength(1); col++)
            {
                if (textIndex < text.Length)
                {
                    gravityMatrix[row, col] = text[textIndex];
                    textIndex++;
                }
                else
                {
                    gravityMatrix[row, col] = ' ';
                }
            }
        }

        return gravityMatrix;
    }
    public static string ConvertWhitespaceToSpacesRegex(string value)
    {
        value = Regex.Replace(value, "[\n\r\t]", " ");
        return value;
    }
}

