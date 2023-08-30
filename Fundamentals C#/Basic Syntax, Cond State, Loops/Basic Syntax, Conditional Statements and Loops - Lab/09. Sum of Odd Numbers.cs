using System;

namespace _9._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int totalSum = 0;
            for(int n = 1; n<=num; n++)
            {
                Console.WriteLine(n*2-1);
                totalSum += n * 2 - 1;
               
            }
            Console.WriteLine($"Sum:{totalSum}");
        }
    }
}
 