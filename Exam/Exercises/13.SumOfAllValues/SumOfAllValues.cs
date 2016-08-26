using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SumOfAllValues
{
    class SumOfAllValues
    {
        static void Main(string[] args)
        {
            // 70/100
            string keyPattern = @"^(?<startKey>[a-zA-Z_]*)(?=[0-9]).*(?<=[0-9])(?<endKey>[a-zA-Z_]*)$";
            string keyString = Console.ReadLine();
            Regex findKeys = new Regex(keyPattern);
            Match keys = findKeys.Match(keyString);

            if (keys.Groups["startKey"].Value == "" || keys.Groups["endKey"].Value == "")
            {
                Console.WriteLine("<p>A key is missing</p>");
                Environment.Exit(Environment.ExitCode);
            }

            string startKey = keys.Groups["startKey"].Value;
            string endKey = keys.Groups["endKey"].Value;
            string numberPattern = startKey + @"(?<number>.*?)" + endKey;
            string textString = Console.ReadLine();

            Regex findNumbers = new Regex(numberPattern);
            MatchCollection numbers = findNumbers.Matches(textString);

            decimal sum = 0.00M;
            string validateNumberPattern = @"^[0-9]*\.{0,1}[0-9]*$";
            Regex validateNumbers = new Regex(validateNumberPattern);

            foreach (Match match in numbers)
            {
                string number = match.Groups["number"].Value;
                Match validatedNumber = validateNumbers.Match(number);
                if (validatedNumber.Success)
                    sum += decimal.Parse(validatedNumber.Value);
            }
            if (sum != 0.00M)
                Console.WriteLine("<p>The total value is: <em>{0:#.##}</em></p>", sum);
            else
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
        }
    }
}
