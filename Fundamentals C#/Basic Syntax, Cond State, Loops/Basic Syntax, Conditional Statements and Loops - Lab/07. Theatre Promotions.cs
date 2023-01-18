using System;

namespace _7._Theatre_Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());            
            double price = 0;
                       

            if (age >= 0 && age <= 18)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                if (day == "Weekend")
                {
                    price = 15;
                }
                if (day == "Holiday")
                {
                    price = 5;
                }
            }
            if (age > 18 && age <= 64)
            {
                if (day == "Weekday")
                {
                    price = 18;
                }
                if (day == "Weekend")
                {
                    price = 20;
                }
                if (day == "Holiday")
                {
                    price = 12;
                }
            }
            if (age > 64 && age <= 122)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                if (day == "Weekend")
                {
                    price = 15;
                }
                if (day == "Holiday")
                {
                    price = 10;
                }
            }
            if (age < 0 || age > 122)
            { 
                Console.WriteLine("Error!");                
            }
            if(price>0)
                Console.WriteLine($"{price}$");

        }
    }
}
