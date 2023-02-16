using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;
            string input;
            int distance = 0;
            bool outOfEnergy = true;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                distance = int.Parse(input);
                if (distance > energy)
                {
                    outOfEnergy=false;
                    break;
                }
                else
                {
                    energy -= distance;
                    wins++;
                }
                if (wins % 3 == 0)
                energy += wins;
            }
            if (outOfEnergy)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
            else
                Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
            
        }
    }
}
