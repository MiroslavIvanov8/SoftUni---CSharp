using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^@(#+)(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])@\1$";
            Regex regex = new Regex(pattern);
            bool validBarcode = false;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);
                string currMatch = match.Groups["product"].Value;
                string productNumber = string.Empty;
                for (int j = 0; j < currMatch.Length; j++)
                {
                    if (Char.IsDigit(currMatch[j]))
                    {
                        productNumber += currMatch[j];
                        validBarcode = true;
                    }
                }
                ;
                if (productNumber.Length>0)
                    Console.WriteLine($"Product group: {productNumber}");
                else if (currMatch.Length == 0)
                    Console.WriteLine("Invalid barcode");
                else if (productNumber.Length == 0)
                    Console.WriteLine("Product group: 00");
                validBarcode = false;

            }
        }
    }
}