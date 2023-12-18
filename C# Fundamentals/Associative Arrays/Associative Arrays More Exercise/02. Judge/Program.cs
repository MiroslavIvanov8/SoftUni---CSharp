using System.Security.Cryptography.X509Certificates;

namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contestResults = new Dictionary<string, Dictionary<string, int>>();
            var individualStandings = new SortedDictionary<string, int>();
            //"{username} -> {contest} -> {points}"
            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputInfo = input.Split(" -> ");
                string name = inputInfo[0];
                string contest = inputInfo[1];
                int points = int.Parse(inputInfo[2]);

                if (!contestResults.ContainsKey(contest))
                {
                    contestResults[contest] = new Dictionary<string, int>();
                    contestResults[contest].Add(name, points);
                }
                else
                {
                    if (!contestResults[contest].ContainsKey(name))
                    {
                        if (contestResults[contest].ContainsKey(name)&& contestResults[contest][name]<points)
                            contestResults[contest][name] = points;
                        else
                        contestResults[contest].Add(name, points);
                        
                    }
                    else if (contestResults[contest][name]<points)
                    {                        
                        contestResults[contest][name] = points;
                    }
                }

            }
            
            foreach (var contest in contestResults)
            {
                Console.WriteLine($" {contest.Key}: {contest.Value.Count} participants");
                int n = 1;
                foreach (var user in contest.Value.OrderByDescending(x=>x.Value)) // 1. Peter <::> 400
                {
                    
                    if(!individualStandings.ContainsKey(user.Key))
                    {
                        individualStandings[user.Key] = 0;
                    }
                    individualStandings[user.Key] += user.Value;
                        
                    Console.WriteLine($" {n++}. {user.Key} <::> {user.Value}");    
                }
            }
            
            Console.WriteLine("Individual standings:");
            int counter = 0;
            foreach (var contest in individualStandings.OrderByDescending(x=>x.Key))
            {
                
                Console.WriteLine($" {++counter}. {contest.Key} -> {contest.Value}");
                
            }
            
           
        }

    }
}