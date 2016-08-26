using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class OlympicsAreComing
{
    static void Main()
    {
        //100/100
        string pattern = @"(?<name>.+?)\s*\|\s*(?<country>.+)";
        Regex rex = new Regex(pattern);
        List<Athlete> athletes = new List<Athlete>();
        Dictionary<string, Country> countries = new Dictionary<string, Country>();

        List<Tuple<string, string>> iteratedAthletes = new List<Tuple<string, string>>();
        List<string> iteratedCountries = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "report")
                break;

            input = input.Trim(' ');
            Match nameAndCountry = rex.Match(input);
            string name = Regex.Replace(nameAndCountry.Groups["name"].Value, @"\s+", " ").Trim(' ');
            string country = Regex.Replace(nameAndCountry.Groups["country"].Value, @"\s+", " ").Trim(' ');

            athletes.Add(new Athlete(name, country));

            if (!countries.ContainsKey(country))
            {
                countries.Add(country, new Country(0, 0, country));
                iteratedCountries.Add(country);
            }

        }

        foreach (Athlete athlete in athletes)
        {
            string name = athlete.Name;
            string country = athlete.Country;
            Tuple<string, string> nameAndCountry = new Tuple<string, string>(name, country);

            if (iteratedAthletes.Contains(nameAndCountry))
            {
                countries[country].Wins++;
            }
            else
            {
                countries[country].Participants++;
                countries[country].Wins++;
                iteratedAthletes.Add(nameAndCountry);
            }
        }

        var query = countries.Where(country => iteratedCountries.Contains(country.Key)).OrderByDescending(country => country.Value.Wins);
        foreach (var country in query)
        {
            string countryName = country.Value.Name;
            int wins = country.Value.Wins;
            int participants = country.Value.Participants;
            Console.WriteLine("{0} ({1} participants): {2} wins", countryName, participants, wins);
        }
    }
}
class Country
{
    public int Participants { get; set; }
    public int Wins { get; set; }
    public string Name { get; set; }
    public Country(int participants, int wins, string name)
    {
        Participants = participants;
        Wins = wins;
        Name = name;
    }
}
class Athlete
{
    public string Name { get; set; }
    public string Country { get; set; }

    public Athlete(string name, string country)
    {
        Name = name;
        Country = country;
    }
}

