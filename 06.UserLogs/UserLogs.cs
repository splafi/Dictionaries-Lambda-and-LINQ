using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem06_user_logs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> ips = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (!input.Equals("end"))
            {
                string[] inputStrings = input.Split(' ');
                string ip = inputStrings[0].Substring(3);
                string userName = inputStrings[2].Substring(5);
                if (!ips.ContainsKey(userName))
                {
                    ips[userName] = new Dictionary<string, int>();
                    ips[userName].Add(ip, 1);
                }
                else
                {
                    if (ips[userName].ContainsKey(ip))
                    {
                        ips[userName][ip]++;
                    }
                    else
                    {
                        ips[userName].Add(ip, 1);
                    }
                }
                input = Console.ReadLine();
            }
            printDictionary(ips);
        }

        private static void printDictionary(SortedDictionary<string, Dictionary<string, int>> ips)
        {
            foreach (string userName in ips.Keys)
            {
                Console.WriteLine($"{userName}: ");
                var ordered = ips[userName].ToDictionary(x => x.Key, x => x.Value);
                string ipString = "";
                foreach (string ip in ordered.Keys)
                {
                    ipString += $"{ip} => {ips[userName][ip]}, ";
                }
                ipString = ipString.Substring(0, ipString.Length - 2);
                ipString += ".";
                Console.WriteLine(ipString);
            }
        }
    }
}