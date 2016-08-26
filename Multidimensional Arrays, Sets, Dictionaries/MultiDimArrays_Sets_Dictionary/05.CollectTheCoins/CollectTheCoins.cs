using System;


class CollectTheCoins
{
    static void Main()
    {
        int wallHits = 0;
        int collectedCoins = 0;
        char[][] array = new char[4][];
        for (int i = 0; i < 4; i++)
        {
            array[i] = Console.ReadLine().ToCharArray();
        }
        char[] commandLine = Console.ReadLine().ToCharArray(); // takes command line

        int row = 0;
        int col = 0;
        for (int i = 0; i < commandLine.Length; i++)
        {
            switch (commandLine[i])
            {
                case 'V':
                    MoveDown(array, ref row, ref col, ref wallHits, ref collectedCoins);
                    break;
                case '^':
                    MoveUp(array, ref row, ref col, ref wallHits, ref collectedCoins);
                    break;
                case '>':
                    MoveRight(array, ref row, ref col, ref wallHits, ref collectedCoins);
                    break;
                case '<':
                    MoveLeft(array, ref row, ref col, ref wallHits, ref collectedCoins);
                    break;
            }
        }

        Console.WriteLine("Coins collected:\n{0}", collectedCoins);
        Console.WriteLine("\nWalls hit: {0}", wallHits);
    }
    static void MoveDown(char[][] array, ref int row, ref int col, ref int wallHits, ref int collectedCoins)
    {
        try
        {
            if (array[row + 1][col] == '$') collectedCoins++;
            row += 1;
        }
        catch(IndexOutOfRangeException)
        {
            wallHits++;
        }
    }
    static void MoveUp(char[][] array, ref int row, ref int col, ref int wallHits, ref int collectedCoins)
    {
        try
        {
            if (array[row - 1][col] == '$') collectedCoins++;
            row -= 1;
        }
        catch (IndexOutOfRangeException e)
        {
            wallHits++;
        }
    }
    static void MoveRight(char[][] array, ref int row, ref int col, ref int wallHits, ref int collectedCoins)
    {
        try
        {
            if (array[row][col + 1] == '$') collectedCoins++;
            col += 1;
        }
        catch (IndexOutOfRangeException e)
        {
            wallHits++;
        }
    }
    static void MoveLeft(char[][] array, ref int row, ref int col, ref int wallHits, ref int collectedCoins)
    {
        try
        {
            if (array[row][col - 1] == '$') collectedCoins++;
            col -= 1;
        }
        catch (IndexOutOfRangeException e)
        {
            wallHits++;
        }
    }
}

