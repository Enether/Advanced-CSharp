using System;
using System.Collections.Generic;
using System.Text;


class LittleJohn
{
    static void Main(string[] args)
    {
        // 62/100
        // a fucking idiotic mistake with not putting <= on index <= inputString.Length-7;
        // shoulda been able to fix it in an exam, god I feel stupid I even felt it might be wrong at the start
        List<string> inputLines = new List<string>();

        for (int i = 0; i < 4; i++)
        {
            inputLines.Add(Console.ReadLine());
        }

        int smallArrows = 0;
        int mediumArrows = 0;
        int largeArrows = 0;
        string smallArrow = ">----->";
        string mediumArrow = ">>----->";
        string largeArrow = ">>>----->>";

        for (int line = 0; line < 4; line++)
        {
            string inputString = inputLines[line];

            for (int index = 0; index <= inputString.Length-7; index++)
            {
                if (inputString[index] == '>')
                {                        
                    if (index + 10 <= inputString.Length)// search for large arrow
                    {
                        if(inputString.Substring(index, 10) == largeArrow) 
                        {
                            index += 9;
                            largeArrows++;
                        }
                        else if (inputString.Substring(index, 8) == mediumArrow) // search for medium arrow
                        {
                            index += 7;
                            mediumArrows++;
                        }
                        else // search for small arrow
                        {
                            if(inputString.Substring(index, 7) == smallArrow)
                            {
                                index += 6;
                                smallArrows++;
                            }
                        }
                    }
                    else if (index + 8 <= inputString.Length)
                    {
                        if (inputString.Substring(index, 8) == mediumArrow)
                        {
                            index += 7;
                            mediumArrows++;
                        }
                        else
                        {
                            if (inputString.Substring(index, 7) == smallArrow)
                            {
                                index += 6;
                                smallArrows++;
                            }
                        }
                    }
                    else
                    {
                        if (inputString.Substring(index, 7) == smallArrow)
                        {
                            index += 6;
                            smallArrows++;
                        }
                    }
                }
            }
        }
        string number = smallArrows.ToString() + mediumArrows + largeArrows;
        string binary = Convert.ToString(int.Parse(number), 2);
        string wholeBinary = binary + ReverseBinary(binary);
        Console.WriteLine(Convert.ToInt32(wholeBinary, 2).ToString());
    }
    public static string ReverseBinary(string binary)
    {
        string oldBinary = binary;
        StringBuilder reverseBinary = new StringBuilder();

        for (int i = oldBinary.Length - 1; i >= 0; i--)
        {
            reverseBinary.Append(oldBinary[i]);
        }

        return reverseBinary.ToString();
    }
}

