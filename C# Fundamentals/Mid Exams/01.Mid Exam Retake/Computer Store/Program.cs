using System;
using System.Diagnostics;

namespace Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPriceNoTax = 0;
            double totalPrice = 0;            
            double tax = 0;
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "regular" || input == "special")
                {
                    break;
                }
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                totalPrice += price;

            }            
            
            if (totalPrice == 0)
                Console.WriteLine("Invalid order!");
            totalPriceNoTax = totalPrice;
            tax = totalPrice * 0.20;
            totalPrice += tax;

            if (input == "special")
                totalPrice *= 0.90;




            if (totalPrice>0)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceNoTax:f2}$");
                Console.WriteLine($"Taxes: {tax:f2}$");
                Console.WriteLine($"-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
            
            
        }
    }
}
