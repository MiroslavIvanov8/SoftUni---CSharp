using System.Text.RegularExpressions;

namespace _02.Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringPattern = @"[^\d]+";
            string numberPattern = @"\d+";
            string input = Console.ReadLine();

            var stringMatch = Regex.Matches(input, stringPattern);
            var numMatch = Regex.Matches(input, numberPattern);
            List<char> chars = new List<char>();

            foreach (Match str in stringMatch)
                for (int i = 0; i < str.ToString().Length; i++)
                {
                    if (!chars.Contains(str.ToString().ToUpper()[i]))
                        chars.Add(str.ToString().ToUpper()[i]);
                }
            Console.WriteLine($"Unique symbols used: {chars.Count}");

            for (int i = 0; i < numMatch.Count; i++)
                for (int j = 0; j < int.Parse(numMatch[i].ToString()); j++)
                {
                    Console.Write(stringMatch[i].ToString().ToUpper());
                }
        }
    }
}