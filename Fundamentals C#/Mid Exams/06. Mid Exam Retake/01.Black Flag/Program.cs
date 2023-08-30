using System;

namespace _01.Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = int.Parse(Console.ReadLine());
            double totalPlunderCollected = 0;
            for (int i = 1; i <= days; i++)
            {
                totalPlunderCollected += dailyPlunder;
                if (i % 3 == 0) // we get 50% bonus every 3rd day
                {
                    
                    totalPlunderCollected += dailyPlunder / 2;
                }
                if (i % 5 == 0) // every 5th day fight a warship and lose 30%
                {
                    totalPlunderCollected *=0.70;
                }              
                
            }
            if (totalPlunderCollected >= targetPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunderCollected:f2} plunder gained.");
            }
            else 
            {                
                Console.WriteLine($"Collected only {totalPlunderCollected/targetPlunder*100:f2}% of the plunder.");
            }
        }
    }
}
