namespace PersonsInfo
{
    public class StartUp

    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new();
            Team team = new("SoftUni");
            for (int i = 0; i < lines; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new(info[0], info[1], int.Parse(info[2]), decimal.Parse(info[3]));
               team.AddPlayer(person);
                
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}