using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>\d+[.]?\d+)\$";
            Regex regex = new Regex(pattern);
            string input;
            double sum = 0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match= regex.Match(input);
                if (regex.IsMatch(input))
                {
                    string name = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    double pricePerProduct = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["count"].Value);
                    Console.WriteLine($"{name}: {product} - {pricePerProduct:f2}");
                    sum += pricePerProduct;
                }
            }
            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}