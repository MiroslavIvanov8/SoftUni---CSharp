namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> Register = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = command[0];
                if (command[0] == "register")
                {
                    string user = command[1];
                    string plate = command[2];
                    if (Register.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                    else
                    {
                        Console.WriteLine($"{user} registered {plate} successfully");
                        Register.Add(user, plate);
                    }
                }
                else 
                {
                    string user = command[1];
                    if (!Register.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                        Register.Remove(user);
                    }
                }
            }
            foreach (var user in Register)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}