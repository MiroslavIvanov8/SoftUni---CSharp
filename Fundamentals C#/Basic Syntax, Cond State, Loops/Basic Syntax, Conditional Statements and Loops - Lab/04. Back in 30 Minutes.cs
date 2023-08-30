using System;

namespace _4._Back_in_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine()) + 30;

            if (hours > 23)
            {   
                hours = 0;
            }
            if (mins > 59)
            {
                hours++;
                mins -= 60;
            }
            Console.WriteLine($"{hours}:{mins:d2}");

        }
    }
}
