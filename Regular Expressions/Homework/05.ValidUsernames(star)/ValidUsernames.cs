using System;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(?<=[\s\/\\\(\)]|^)[A-Za-z][A-Za-z0-9_]{2,24}(?=[\s\/\\(\)]|$)";
        Regex findUsernames = new Regex(pattern);
        MatchCollection usernames = findUsernames.Matches(input);
        long recordSum = 0;
        long sum = 0;
        for (int i = 0; i < usernames.Count; i++)
        {
            long lengthOfUsername = usernames[i].ToString().Length;
            sum += lengthOfUsername;

            if(i != 0)
            {
                if (sum > recordSum)
                    recordSum = sum;

                sum = lengthOfUsername;
            }
        }
        sum = 0;
        for (int i = 0; i < usernames.Count; i++)
        {
            long lengthOfUsername = usernames[i].ToString().Length;
            sum += lengthOfUsername;

            if (i != 0)
            {
                if (sum == recordSum)
                {
                    Console.WriteLine(usernames[i-1].ToString());
                    Console.WriteLine(usernames[i].ToString());
                    break;
                }

                sum = lengthOfUsername;
            }
        }
    }
}

