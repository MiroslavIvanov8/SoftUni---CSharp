using System.Net.Security;
using System.Text.RegularExpressions;
using System.Xml;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitures = new List<string>();
            string input = string.Empty;
            double price = 0;

            string pattern = @">>(?<item>[A-z]+)<<(?<price>\d+[.]?[0-9]+)!(?<quantity>\d+)";
            Regex  regex= new Regex(pattern);
            while ((input = Console.ReadLine()) != "Purchase")
            {
                bool isMatched = regex.IsMatch(input);
                if (isMatched)
                {
                    Match match = regex.Match(input);
                    furnitures.Add(match.Groups["item"].Value);
                    price += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);

                }
            }
            Console.WriteLine($"Bought furniture:");
            foreach (string furniture in furnitures)
            {
                Console.WriteLine(furniture);
            }
            Console.WriteLine($"Total money spend: {price:f2}");

        }   
    }
}