using static System.Net.Mime.MediaTypeNames;

namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var types = new Dictionary<string,List<string>>(); // type and name
            var stats = new Dictionary<string,Dragon>(); // name and stats
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split(" ");
                string type = inputArgs[0];
                string name = inputArgs[1];
                string damageAsString = inputArgs[2];
                string healthAsString = inputArgs[3];
                string armourAsString = inputArgs[4];
                int damage = 0;
                int health = 0;
                int armour = 0;

                if (damageAsString == "null")
                {
                    damage = 45;
                }

                else
                {
                    damage = int.Parse(damageAsString);
                }
                if (healthAsString == "null")
                {
                    health = 250;
                }
                else
                {
                    health = int.Parse(healthAsString);
                }
                if (armourAsString == "null")
                {
                    armour = 10;
                }
                else
                {
                    armour = int.Parse(armourAsString);
                }

                if (!types.ContainsKey(type))
                {
                    types[type] = new List<string>();
                    types[type].Add(name);
                }
                else
                {
                    if (!types[type].Contains(name))
                    types[type].Add(name);
                }

                if (!stats.ContainsKey(name))
                {
                    stats[name] = new Dragon() { Damage = damage, Health = health, Armour = armour };
                }
                else
                {
                    stats[name].Damage = damage;
                    stats[name].Health = health;
                    stats[name].Armour = armour;

                }        
            }
            foreach (var color in types)
            {
                double avrDamage = 0;
                double avrHealth = 0;
                double avrArmour = 0;
                foreach (var dragon in stats)
                {
                    if (color.Value.Contains(dragon.Key))
                    {
                        avrDamage += dragon.Value.Damage;
                        avrHealth+= dragon.Value.Health;
                        avrArmour+= dragon.Value.Armour;

                    }
                }
                ;
                int count = color.Value.Count;
                avrDamage /= count;
                avrHealth /= count;
                avrArmour /= count;

                Console.WriteLine($"{color.Key}::({avrDamage:f2}/{avrHealth:f2}/{avrArmour:f2})");

                foreach (var dragon in color.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-{dragon} -> damage: {stats[dragon].Damage}, health: {stats[dragon].Health}, armor: {stats[dragon].Armour}");
                }
            }
        }
        class Dragon
        {
            public int Damage { get; set; }
            public int Health { get; set; }
            public int Armour { get; set; }
        }
    }
}