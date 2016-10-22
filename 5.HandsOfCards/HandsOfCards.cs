using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Hands_of_Cards
{
    class Program
    {
        static void Main()
        {
            char[] separators = { ':', ',',' ' };
            string key = "";            
            var cardHolder = new Dictionary<string, string>();
            Dictionary<string, int> cardType = new Dictionary<string, int>()
            {
                {"S", 4}, {"H", 3}, {"D", 2}, {"C", 1}
            };
            Dictionary<string, int> cardPower = new Dictionary<string, int>()
            {
                {"1",1}, {"2",2}, {"3",3}, {"4",4}, {"5",5}, {"6",6}, {"7",7},
                {"8",8}, {"9",9}, {"10",10}, {"J",11}, {"Q",12}, {"K",13}, {"A",14}
            };
           
            while (key != "JOKER")
            {
                string[] input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                key = input[0];
                if (key == "JOKER")
                {
                    break;
                }
                string cardsHeld = string.Join(" ",input.Skip(1).ToArray());                
                if (cardHolder.ContainsKey(key))
                {
                    cardHolder[key] += " " + cardsHeld;
                }
                else
                {
                    cardHolder.Add(key, cardsHeld);                    
                }                
            }
            foreach (var item in cardHolder)
            {
                string[] temp = cardHolder[item.Key].Split(' ').Distinct().ToArray();
                int value = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    string[] card = { temp[i].Substring(0, temp[i].Length - 1), temp[i][temp[i].Length - 1].ToString() };
                    value += cardPower[card[0]] * cardType[card[1]];
                }              
                Console.WriteLine($"{item.Key}: {value}");
            }
        }
    }
}