using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dwarves = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArgs = input.Split(" <:> ");
                string dwarfName = inputArgs[0];
                string hatColor = inputArgs[1];
                int dwarfPhysics = int.Parse(inputArgs[2]);
                if (!dwarves.ContainsKey(hatColor))
                {
                    dwarves[hatColor]=new Dictionary<string, int>();
                    dwarves[hatColor][dwarfName]=dwarfPhysics;
                }
                else
                {
                    if (dwarves[hatColor].ContainsKey(dwarfName))
                    {
                        if (dwarves[hatColor][dwarfName] < dwarfPhysics)
                            dwarves[hatColor][dwarfName] = dwarfPhysics;
                    }
                    else if(!dwarves[hatColor].ContainsKey(dwarfName))
                    {
                        dwarves[hatColor].Add(dwarfName, dwarfPhysics);
                    }
                }
            }

            foreach (var dwarf in dwarves.OrderByDescending(x => x.Key))
            {
                foreach (var kvp in dwarf.Value.OrderBy(dv=>dv.Value))
                {
                    Console.WriteLine($"({dwarf.Key}) {kvp.Key} <-> {kvp.Value}");
                }
            }
        }
    }
}