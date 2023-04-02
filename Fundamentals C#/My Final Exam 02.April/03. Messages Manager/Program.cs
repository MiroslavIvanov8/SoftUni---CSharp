namespace _03._Messages_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string command = string.Empty;
            var register = new Dictionary<string, Massage>();
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command.Split("=");

                if (commandArgs[0] == "Add")
                {
                    string username = commandArgs[1];
                    int sentMassages = int.Parse(commandArgs[2]);
                    int receivedMassages = int.Parse(commandArgs[3]);
                    if (!register.ContainsKey(username))
                    {
                        register.Add(username, new Massage() { Sent = sentMassages, Received = receivedMassages });
                    }
                    else
                        continue;
                }
                else if (commandArgs[0] == "Message")
                {
                    string sender = commandArgs[1];
                    string receiver = commandArgs[2];
                    if (register.ContainsKey(sender) && register.ContainsKey(receiver))
                    {
                        register[sender].Sent += 1;
                        register[receiver].Received += 1;
                        if (register[sender].Sent + register[sender].Received >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            register.Remove(sender);
                        }
                        if (register[receiver].Sent + register[receiver].Received >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            register.Remove(receiver);
                        }
                    }
                }
                else if (commandArgs[0] == "Empty")
                {
                    string username = commandArgs[1];
                    if (register.ContainsKey(username))
                        register.Remove(username);
                    if (username == "All")
                        register.Clear();
                }
            }
            Console.WriteLine($"Users count: {register.Count}");
            foreach (var user in register)
            {
                int totalMassages = user.Value.Sent + user.Value.Received;
                Console.WriteLine($"{user.Key} - {totalMassages}");
            }

        }
        class Massage
        {
            public int Sent { get; set; }
            public int Received { get; set; }
        }
    }
}