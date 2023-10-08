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

            Dictionary<string, Predicate<string>> filters = new();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string filter = commandArgs[1];
                string value = commandArgs[2];

                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine($"{string.Join(", ", guests)}");
            
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return n => n.StartsWith(value);
                case "Ends with":
                    return n => n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                case "Contains":
                    return n => n.Contains(value);
                default:
                    return default;

            }
        }
    }
}