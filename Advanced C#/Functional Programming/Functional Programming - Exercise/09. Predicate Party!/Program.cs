using System.IO;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries).
                 ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string filter = commandArgs[1];
                string value = commandArgs[2];

                if (action == "Remove")
                {
                    guests.RemoveAll(GetPredicate(filter, value));
                }

                if (action == "Double")
                {
                    List<string> peopleToDouble = guests.FindAll(GetPredicate(filter, value));
                    foreach (string person in peopleToDouble)
                    {
                        int index = guests.FindIndex(p => p == person);
                        guests.Insert(index, person);
                    }
                }
            }

            if (guests.Any())
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return n => n.StartsWith(value);
                case "EndsWith":
                    return n => n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                default:
                    return default;

            }
        }
    }
}