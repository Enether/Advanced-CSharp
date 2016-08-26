using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class TheNumbers
{
    static void Main()
    {
        // 100/100 easiest one yet
        List<string> hexList = new List<string>();
        Regex rex = new Regex(@"[\d]+");
        MatchCollection matches = rex.Matches(Console.ReadLine());

        foreach (Match match in matches)
        {
            StringBuilder hexSB = new StringBuilder();
            string hexValue = int.Parse(match.Value).ToString("X"); // converts to hex
            hexSB.Append("0x");

            if(hexValue.Length != 4)
            {
                for (int i = 0; i < 4-hexValue.Length; i++)
                {
                    hexSB.Append("0");
                }
            }

            hexSB.Append(hexValue);
            hexList.Add(hexSB.ToString());
        }

        int lastIndex = hexList.Count() - 1;
        for (int i = 0; i < lastIndex; i++)
        {
            Console.Write(hexList[i] + "-");
        }
        Console.Write(hexList[lastIndex]);
    }
}

