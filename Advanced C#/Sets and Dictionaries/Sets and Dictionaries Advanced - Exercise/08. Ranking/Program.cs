using System.Collections.Generic;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPassword = new();
            Dictionary<string,Dictionary<string, int>> contests = new();
            Dictionary<string, int> candidates = new();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = command.Split(":",StringSplitOptions.RemoveEmptyEntries);
                string contestName = contestInfo[0];
                string password = contestInfo[1];
                if (!contestPassword.ContainsKey(contestName))
                {
                    contestPassword.Add(contestName, password);
                    contests.Add(contestName, new Dictionary<string, int>());                    
                }
                else
                    continue;
            }
            string submissions = string.Empty;
            while ((submissions = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionsInfo = submissions.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = submissionsInfo[0];
                string password = submissionsInfo[1];
                string name = submissionsInfo[2];
                int points = int.Parse(submissionsInfo[3]);

                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (!contests[contest].ContainsKey(name))
                    {
                        contests[contest].Add(name,0);
                        contests[contest][name] = points;
                        if (!candidates.ContainsKey(name))
                            candidates[name] = 0;
                    }

                    if(contests[contest].ContainsKey(name))
                        if(contests[contest][name] < points)
                            contests[contest][name] = points;
                }

            }
            string bestCandidate = string.Empty;
            int bestPoints = 0;
            
            
            foreach(var candidate in candidates)
            {
                int currPoints = 0;
                foreach (var contest in contests)
                {
                    foreach (var currCandidate in contest.Value)
                    {
                        if (candidate.Key == currCandidate.Key)
                        {
                            currPoints += currCandidate.Value;
                        }
                    }
                    
                }
                if (currPoints > bestPoints)
                {
                    bestCandidate = candidate.Key;
                    bestPoints = currPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            contests = contests.OrderBy(x => x.Value.Keys).ToDictionary(x => x.Key, x => x.Value);
            ;
            //foreach (var candidate in candidates.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(candidate.Key);
            //    foreach (var contest in contests.OrderByDescending(x => x.Value.Values.Sum()))
            //    {
            //        if (contest.Value.ContainsKey(candidate.Key))
            //        {
            //            Console.WriteLine($"# {contest.Key} -> {0}");
            //        }
            //    }
            //    
            //}
        }
    }
    

}