using System.Globalization;

namespace _01._Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Abracadabra")
            {
                string[] commandArgs = command.Split(" ");
                if (commandArgs.Length == 0)
                    continue;
                if (commandArgs[0] == "Abjuration")
                {
                    string upperSpell = string.Empty;
                    foreach (char ch in spell)
                    {
                        upperSpell += char.ToUpper(ch);
                    }
                    spell = upperSpell;
                    Console.WriteLine(spell);
                }
                else if (commandArgs[0] == "Necromancy")
                {
                    string lowerSpell = string.Empty;
                    foreach (char ch in spell)
                    {
                        lowerSpell += char.ToLower(ch);
                    }
                    spell = lowerSpell;
                    Console.WriteLine(spell);
                }
                else if (commandArgs[0] == "Illusion")
                {
                    int index = int.Parse(commandArgs[1]);
                    string letter = commandArgs[2];
                    if (index < 0 || index > spell.Length)
                        Console.WriteLine("The spell was too weak.");
                    else
                    {
                        spell = spell.Remove(index,1);
                        spell = spell.Insert(index, letter);
                        Console.WriteLine("Done!");
                    }
                }
                else if (commandArgs[0] == "Divination")
                {
                    string oldSubstring = commandArgs[1];
                    string newSubstring = commandArgs[2];
                    if (spell.Contains(oldSubstring))
                    {
                        spell = spell.Replace(oldSubstring, newSubstring);
                        Console.WriteLine(spell);
                    }
                    else
                        continue;
                }
                else if (commandArgs[0] == "Alteration")
                {
                    string substring = commandArgs[1];
                    if (spell.Contains(substring))
                    {
                        int index = spell.IndexOf(substring);
                        spell = spell.Remove(index, substring.Length);
                        Console.WriteLine(spell);
                    }
                    else
                        continue;
                }
                else
                    Console.WriteLine("The spell did not work!");


            }


        }
    }
}