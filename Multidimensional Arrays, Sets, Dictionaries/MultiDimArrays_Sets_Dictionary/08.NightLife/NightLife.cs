using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> cities = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END")
                break;
            // reads command and assigns it accordingly
            string city = "";
            string venue = "";
            string performer = "";
           
            Match match = Regex.Match(command, @"^(?<City>.*);(?<Venue>.*);(?<Performer>.*)$");  // I use regular expressions here, if you're studying in SoftUni you'll learn what this is in a week or two

            city = match.Groups["City"].ToString();
            venue = match.Groups["Venue"].ToString();
            performer = match.Groups["Performer"].ToString();

            // checks and creates info
            if (!cities.ContainsKey(city))
            {
                cities[city] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!cities[city].ContainsKey(venue))
            {
                cities[city][venue] = new SortedSet<string>();
            }
            if (!cities[city][venue].Contains(performer))
            {
                cities[city][venue].Add(performer);
            }
        }

        // prints out everything
        foreach (var sortedDictionary in cities)
        {
            Console.WriteLine(sortedDictionary.Key);

            foreach (var sortedSet in sortedDictionary.Value)
            {
                Console.Write("->{0}: ", sortedSet.Key);
                Console.WriteLine(string.Join(", ", sortedSet.Value));
            }
        }
    }
}

