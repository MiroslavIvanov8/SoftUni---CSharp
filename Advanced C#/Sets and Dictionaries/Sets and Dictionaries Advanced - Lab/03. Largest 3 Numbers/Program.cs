﻿namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            numbers = numbers.OrderByDescending(x => x)
                .Take(3)
                .ToArray();
            
                Console.Write(string.Join(" ", numbers));            
           
        }
    }
}