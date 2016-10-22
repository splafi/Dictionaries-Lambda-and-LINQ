using System;
using System.Collections.Generic;
class Phonebook
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        while (input[0] != "END")
        {
            if (input[0] == "A")
            {
                string name = input[1];
                string number = input[2];
                if (phonebook.ContainsKey(name))
                {
                    phonebook[name] = number;
                }
                else
                {
                    phonebook.Add(name, number);
                }
            }
            else
            {
                string searchedName = input[1];
                if (phonebook.ContainsKey(searchedName))
                {
                    Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchedName} does not exist.");
                }
            }
            input = Console.ReadLine().Split();
        }
    }
}