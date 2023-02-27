namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<string> members = new List<string>();
            bool canWeCreateATeam = true;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-");
                string teamCreator = teamInfo[0];
                string teamName = teamInfo[1];

                foreach (Team team in teams)
                {
                    canWeCreateATeam=true;
                    if (teamName == team.TeamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");// case where team is already created
                        canWeCreateATeam=false;
                        break;
                    }
                    if (teamCreator == team.Creator)
                    {
                        Console.WriteLine($"{teamCreator} cannot create another team!"); // case where user already created a team 
                        canWeCreateATeam = false;
                        break;
                    }                   
                }
                // case where we create a new team 
                if (canWeCreateATeam)
                {
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                    Team Ateam = new Team(teamCreator, teamName, members);
                    
                    teams.Add(Ateam);
                } 
            }
            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] joinInfo = input.Split("->");
                string user = joinInfo[0];
                string teamToJoin = joinInfo[1];
                bool canJoin = false;

                foreach (Team Ateam in teams)
                {
                    canJoin = true;
                    foreach (string member in Ateam.TeamMembers) // case where user is already in a team
                    {
                        if (user == member || user == Ateam.Creator)
                        {
                            Console.WriteLine($"Member {user} cannot join team {Ateam.TeamName}!");
                            canJoin = false;
                            break;
                        }
                    }
                    if (!canJoin)
                        break;
                    if (teamToJoin != Ateam.TeamName) // joining a nonexisting team // need to to through all teams and then write the massage
                    {
                        Console.WriteLine($"Team {teamToJoin} does not exist!");
                        canJoin = false;
                        continue;
                    }
                    
                    if (canJoin)
                    {
                        Ateam.TeamMembers.Add(user);
                        break;
                    }
                }

            }
        }
    }
    
        
    class Team
    {
        // constructor
        public Team(string teamCreator, string teamName, List<string> members)
        {
            this.Creator= teamCreator;
            this.TeamName=teamName;
            this.TeamMembers = members;
        }

        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List <string> TeamMembers { get; set;}
    }
}