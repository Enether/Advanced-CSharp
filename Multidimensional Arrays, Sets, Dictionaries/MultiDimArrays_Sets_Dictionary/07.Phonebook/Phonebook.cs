using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        var phonebook = FillPhonebook();

        SearchPhonebook(phonebook);       
    }
    static Dictionary<string, string> FillPhonebook()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        string command = "";
        while (command != "search")
        {
            command = Console.ReadLine();
            string name = "";
            string number = "";
            bool saveName = true;
            foreach (char character in command) // goes through the input and separates it
            {
                if (character == '-') saveName = false;

                else if (saveName)
                    name += character;
                else
                    number += character;
            }

            if (phonebook.ContainsKey(name)) // adds another phone to the contact
            {
                phonebook[name] += " and " + number;
            }
            else
            {
                phonebook.Add(name, number);
            }
        }
        return phonebook;
    }
    static void SearchPhonebook(Dictionary<string, string> phonebook)
    {
        string command = "";
        while (true)
        {
            command = Console.ReadLine();
            if (phonebook.ContainsKey(command))
            {
                Console.WriteLine("{0} -> {1}", command, phonebook[command]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", command);
            }
        }
    }
}

