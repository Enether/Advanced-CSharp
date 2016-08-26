using System;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] words = Console.ReadLine().Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        decimal sum = 0m;
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            char firstLetter = word[0];
            char secondLetter = word[word.Length - 1];

            string numberStr = "";
            for (int j = 1; j < word.Length - 1; j++)
            {
                numberStr += word[j];
            }

            decimal number = 0m;
            decimal.TryParse(numberStr, out number);

            if (char.IsUpper(firstLetter))
            {
                number /= GetPosition(firstLetter);
            }
            else
            {
                number *= GetPosition(firstLetter);
            }

            if (char.IsUpper(secondLetter))
            {
                number -= GetPosition(secondLetter);
            }
            else
            {
                number += GetPosition(secondLetter);
            }

            sum += number;
        }
        Console.WriteLine("{0:0.00}", sum);
    }
    static int GetPosition(char letter)
    {
        int position = char.ToUpper(letter) - 64;

        return position;
    }
}

