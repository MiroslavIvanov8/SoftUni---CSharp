using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=|/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            int travelPoints = 0;
            MatchCollection match = regex.Matches(input);
            List<string> destinations= new List<string>();
            foreach (Match m in match)
            {
                string destination = m.Groups["destination"].Value;
                destinations.Add(destination);
                int destinationLength = destination.Length;
                travelPoints+= destinationLength;
            }            
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}