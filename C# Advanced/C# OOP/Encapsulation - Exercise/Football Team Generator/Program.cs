namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, Team> teams = new();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[1];
                if (commandArgs[0] == "Team")
                {

                    if (!teams.ContainsKey(name))
                    {
                        Team team = new Team(commandArgs[1]);
                        teams.Add(name, team);
                    }
                }
                else if (commandArgs[0] == "Add")
                {

                    if (!teams.ContainsKey(name))
                    {
                        Console.WriteLine("Team [team name] does not exist.");
                    }
                    else
                    {
                        string playerName = commandArgs[2];
                        int endur = int.Parse(commandArgs[3]);
                        int sprint = int.Parse(commandArgs[4]);
                        int dribble = int.Parse(commandArgs[5]);
                        int passing = int.Parse(commandArgs[6]);
                        int shooting = int.Parse(commandArgs[7]);
                        try
                        {
                            Player player = new(playerName, endur, sprint, dribble, passing, shooting);
                            teams[name].Add(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    teams[name].Remove(commandArgs[2]);

                }
                else if (commandArgs[0] == "Rating")
                {
                    if (teams.ContainsKey(name))
                    {
                        double teamRating = Math.Round(teams[name].Rating);
                        Console.WriteLine($"{name} - {(int)teamRating}");
                    }
                    else
                        Console.WriteLine($"Team {name} does not exist.");
                }
            }
        }
    }
}