using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VladkosNotebook
{
    class VladkosNotebook
    {
        // This class is not in a separate .cs file only because I want the automated judge system to be able to read the code
        class Colors
        {
            public string Color { get; set; }
            public string PlayerName { get; set; }
            public int Age { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }
            public string OpponentName { get; set; }
            public Colors()
            {
            }
        }
        static void Main(string[] args)
        {
            List<Colors> colorsList = AssimilateInput();

            // gets an array with all the colors used.
            IEnumerable<string> uniqueColors = colorsList
                .GroupBy(color => color.Color)
                .Select(color => color.First().Color.ToString());

            uniqueColors = uniqueColors.OrderBy(c => c);
            bool anythingWritten = false;
            foreach (string uniqueColor in uniqueColors)
            {
                int age = -1;
                string playerName = "";
                List<string> opponents = new List<string>();
                int wins = 0;
                int losses = 0;

                foreach (Colors color in colorsList)
                {

                    if(color.Color == uniqueColor)
                    {
                        if (color.OpponentName != null)
                        {
                            opponents.Add(color.OpponentName);

                            if (color.Wins != 0)
                                wins++;
                            else if (color.Losses != 0)
                                losses++;
                        }
                        else if (color.Age > -1)
                        {
                            age = color.Age;
                        }
                        else if (color.PlayerName != null)
                        {
                            playerName = color.PlayerName;
                        }
                                                
                    }
                }

                bool eligibleToPrint = (age != -1) && (playerName != "");
                if (eligibleToPrint)
                {
                    anythingWritten = true;
                    Print(uniqueColor, age, playerName, opponents, wins, losses);
                }
            }

            if (anythingWritten == false)
                Console.WriteLine("No data recovered.");
        }
        static List<Colors> AssimilateInput()
        {
            List<Colors> colorsList = new List<Colors>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                    break;

                string[] info = input.Split('|');

                string color = info[0];
                int age = 0;
                string name = "";
                string opponentName = "";

                Colors colorSheet = new Colors();
                colorSheet.Color = color;
                colorSheet.Age = -1;
                switch (info[1])
                {
                    case "age":
                        age = int.Parse(info[2]);
                        colorSheet.Age = age;
                        break;
                    case "name":
                        name = info[2];
                        colorSheet.PlayerName = name;
                        break;
                    case "win":
                        opponentName = info[2];
                        colorSheet.Wins = 1;
                        colorSheet.OpponentName = opponentName;
                        break;
                    case "loss":
                        opponentName = info[2];
                        colorSheet.Losses = 1;
                        colorSheet.OpponentName = opponentName;
                        break;
                }

                colorsList.Add(colorSheet);
            }
            return colorsList;
        }
        static void Print(string uniqueColor, int age, string playerName, List<string> opponents, int wins, int losses)
        {
            Console.WriteLine("Color: {0}", uniqueColor);
            Console.WriteLine("-age: {0}", age);
            Console.WriteLine("-name: {0}", playerName);

            if (opponents.Count == 0)
                Console.WriteLine("-opponents: (empty)");
            else
            {
                Console.WriteLine("-opponents: {0}", string.Join(", ", opponents.OrderBy(x => x, StringComparer.Ordinal)));
            }

            Console.WriteLine("-rank: {0:0.00}", Math.Round((decimal)(wins + 1) / (losses + 1), 2));
        }
    }
}

