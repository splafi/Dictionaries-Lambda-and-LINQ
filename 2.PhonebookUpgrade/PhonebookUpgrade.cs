using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PhonebookUpgrade
{
    class Program
    {
        static SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splited = input.Split(' ');
                switch (splited[0])
                {
                    case "A": Add(splited[1], splited[2]); break;
                    case "S": Find(splited[1]); break;
                    case "ListAll":
                        ListAll();
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void Add(string name, string phone)
        {
            if (!sorted.ContainsKey(name))
            {
                sorted.Add(name, phone);
            }
            else
            {
                sorted[name] = phone;
            }
        }

        private static void Find(string searchedName)
        {
            int count = 0;
            foreach (var name in sorted)
            {
                if (name.Key.Equals(searchedName))
                {
                    Console.WriteLine($"{name.Key} -> {name.Value}");
                    count++;
                    break;
                }

            }
            if (count == 0)
            {
                Console.WriteLine($"Contact {searchedName} does not exist.");
            }
        }

        private static void ListAll()
        {
            foreach (var name in sorted)
            {
                Console.WriteLine($"{name.Key} -> {name.Value}");
            }
        }
    }
}