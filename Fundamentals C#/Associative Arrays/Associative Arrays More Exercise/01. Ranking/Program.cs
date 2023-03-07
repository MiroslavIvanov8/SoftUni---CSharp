namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            var contestsAndPass = new Dictionary<string, string>();
            var userPoints = new SortedDictionary<string, Dictionary<string, int>>(); ////Key -> name, Value -> Key: contest, Value: points


            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = input.Split(":");
                string contestName = contestInfo[0];
                string contestPass = contestInfo[1];
                contestsAndPass.Add(contestName, contestPass);
            }

            string input2;            
            while ((input2 = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = input2.Split("=>");
                string contest = userInfo[0];
                string pass = userInfo[1];
                string name = userInfo[2];
                int points = int.Parse(userInfo[3]);

                if (userPoints.ContainsKey(name) && userPoints[name].ContainsKey(contest))
                {
                    if (userPoints[name][contest] < points)
                        userPoints[name][contest] = points;
                }
                else if (userPoints.ContainsKey(name))
                {
                    if (contestsAndPass[contest] == pass)
                    {
                        userPoints[name].Add(contest, points);
                    }
                }
                else
                {
                    if (contestsAndPass.ContainsKey(contest))
                    {
                        if (contestsAndPass[contest] == pass)
                        {
                            userPoints.Add(name, new Dictionary<string, int>());
                            userPoints[name].Add(contest, points);
                        }
                    }
                }                          
            }
            // find the best candidate
            string bestCandidate = string.Empty;
            int bestPoints = 0;
            foreach (var user in userPoints)
            {
                if (user.Value.Values.Sum() > bestPoints)
                {
                    bestCandidate = user.Key;
                    bestPoints = user.Value.Values.Sum();
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in userPoints)
            {
                Console.WriteLine(user.Key);
                Console.WriteLine(string.Join(Environment.NewLine, user.Value.OrderByDescending(p => p.Value).Select(u => $"# {u.Key} ->{u.Value}")));
            }
        }
    }
}