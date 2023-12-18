using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();
            Dictionary<string, int> players= new Dictionary<string, int>();
            string input = string.Empty;
            Regex regex = new Regex(@"\w");
            
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection matchCollection= regex.Matches(input);
                string name = string.Empty;
                int distance = 0;
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    
                    char ch = char.Parse(matchCollection[i].Value);
                    if (char.IsLetter(ch))
                    {
                        name += ch;
                    }
                    else
                    {
                        int km = int.Parse(matchCollection[i].Value);
                        distance+= km;
                    }
                }
                if (participants.Contains(name))
                {
                    if (!players.ContainsKey(name))
                    {
                        players.Add(name, distance);
                    }
                    else
                        players[name] += distance;
                }
            }
            var sorterRanking = players.OrderByDescending(km => km.Value);
            
            int place = 1;
            foreach(var player in sorterRanking)
            {
                if (place > 3)
                    break;
                if(place==1)
                Console.WriteLine($"{place}st place: {player.Key}");
                if(place == 2)
                    Console.WriteLine($"{place}nd place: {player.Key}");
                if (place == 3)
                    Console.WriteLine($"{place}rd place: {player.Key}");
                place++;                


            }
        }
    }
}