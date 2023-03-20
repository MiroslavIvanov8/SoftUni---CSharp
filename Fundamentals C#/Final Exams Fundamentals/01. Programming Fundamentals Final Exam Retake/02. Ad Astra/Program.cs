using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([|#])(?<food>[A-Za-z\s]+)\1(?<expireDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(input);
            int totalCalories = 0;
            foreach (Match m in match)
            {
                totalCalories += int.Parse(m.Groups["calories"].Value);
            }
            int days = totalCalories/ 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            
                foreach (Match m in match)
                {
                    Console.WriteLine($"Item: {m.Groups["food"]}, Best before: {m.Groups["expireDate"]}, Nutrition: {m.Groups["calories"]}");
                }
            
        }
    }
}