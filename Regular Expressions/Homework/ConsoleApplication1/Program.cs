using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string wholeInput = "";
            while(command != "END")
            {
                wholeInput += command;
                command = Console.ReadLine();
            }
            DumpHRefs(wholeInput);
        }
        private static void DumpHRefs(string inputString)
        {
            Match m;
            string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            try
            {
                m = Regex.Match(inputString, HRefPattern,
                                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    Console.WriteLine("Found href " + m.Groups[1] + " at "
                       + m.Groups[1].Index);
                    m = m.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The matching operation timed out.");
            }
        }
    }
}
