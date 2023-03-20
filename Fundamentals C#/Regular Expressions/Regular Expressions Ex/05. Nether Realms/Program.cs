using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> demonsNames= Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var demons = new SortedDictionary<string, List<Demon>>();
            string health = @"[^\d\+\-\*\/.]";
            string damage = @"(?<numbers>([-|+]\d*[.]?\d+)|(\d*[.]?\d+))";
            string symbols = @"[\/*]";

            for (int i = 0; i < demonsNames.Count; i++)
            {
                var healthMatch = Regex.Matches(demonsNames[i],health);
                var damageMatch = Regex.Matches(demonsNames[i],damage);
                var symbolsMatch = Regex.Matches(demonsNames[i], symbols);

                double damageSum = 0;
                double healthSum = 0;
                foreach (Match match in damageMatch)                
                    damageSum += double.Parse(match.ToString());
                foreach (Match match in healthMatch)
                    healthSum += char.Parse(match.ToString());
                foreach (Match match in symbolsMatch)
                {
                    if (match.ToString() == "*")
                        damageSum *= 2;
                    else
                        damageSum /= 2;
                }
                Demon demon = new Demon { Health = healthSum, Damage = damageSum };
                demons[demonsNames[i]] = new List<Demon>();
                demons[demonsNames[i]].Add(demon);
            }
            foreach (var demon in demons)
                foreach (var sum in demons[demon.Key])
                {
                    Console.WriteLine($"{demon.Key} - {sum.Health} health, {sum.Damage:f2} damage");
                }
        }
        class Demon
        {
            public double Health { get; set; }
            public double Damage { get; set; }
        }
    }
}