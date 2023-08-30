using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> destroyedPlanets = new List<string>();
            List<string> attackedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int key = 0;
                string input = Console.ReadLine();
                string massage = string.Empty;
                foreach (char ch in input)
                {
                    if (ch == 's' | ch == 'S' | ch == 'a' | ch == 'A' | ch == 't' | ch == 'T' | ch == 'r' | ch == 'R')
                        key++;
                }
                for (int j = 0; j < input.Length; j++)
                {
                    massage += (char)(input[j] - key);
                }
                string pattern = @"(?<name>[A-Z][a-z]+)[^@\-!,:>]*?:(?<population>\d+)[^@\-!,:>]*?!(?<attackType>(A|D))![^@\-!,:>]*?->(?<soliders>\d+)";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(massage))
                {
                    Match match = regex.Match(massage);
                    string attackType = match.Groups["attackType"].Value;
                    if (attackType == "D")
                        destroyedPlanets.Add(match.Groups["name"].Value);
                    else
                        attackedPlanets.Add(match.Groups["name"].Value);
                }
            }
            destroyedPlanets.Sort();
            attackedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}