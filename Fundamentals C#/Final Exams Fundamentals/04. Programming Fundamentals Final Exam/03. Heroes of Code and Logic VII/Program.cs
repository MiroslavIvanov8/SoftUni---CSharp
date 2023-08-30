using System.Reflection.Metadata;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var party = new Dictionary<string,Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);
                Hero hero = new Hero() {HP = hp,MP=mp };
                party.Add(name,hero);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" - ");
                string name = commandArgs[1];
                if (commandArgs[0] == "CastSpell")
                {
                    int mPNeeded = int.Parse(commandArgs[2]);
                    string spellName = commandArgs[3];
                    if (party[name].MP >= mPNeeded)
                    {
                        party[name].MP -= mPNeeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {party[name].MP} MP!");
                    }
                    else
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                }
                else if (commandArgs[0] == "TakeDamage")
                {
                    int damageTaken = int.Parse(commandArgs[2]);
                    string attacker = commandArgs[3];
                    party[name].HP -= damageTaken;
                    if (party[name].HP > 0)
                        Console.WriteLine($"{name} was hit for {damageTaken} HP by {attacker} and now has {party[name].HP} HP left!");
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        party.Remove(name);
                    }
                }
                else if (commandArgs[0] == "Recharge")
                {
                    int amount = int.Parse(commandArgs[2]);

                    if (party[name].MP + amount > 200)
                    {
                        int diff = 200 - party[name].MP;
                        party[name].MP = 200;
                        Console.WriteLine($"{name} recharged for {diff} MP!");
                    }
                    else
                    {
                        party[name].MP += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }

                }
                else if (commandArgs[0] == "Heal")
                {
                    int amount = int.Parse(commandArgs[2]);
                    if (party[name].HP + amount > 100)
                    {
                        int diff = 100 - party[name].HP;
                        party[name].HP = 100;
                        Console.WriteLine($"{name} healed for {diff} HP!");
                    }
                    else
                    {
                        party[name].HP += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }
            }
            foreach (var hero in party)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP} ");
                Console.WriteLine($"  MP: {hero.Value.MP} ");
            }
        }
        public class Hero
        {            
            public int HP { get; set; }
            public int MP { get; set; }
        }
    }
}