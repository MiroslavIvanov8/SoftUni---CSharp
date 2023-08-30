using System;
using System.Drawing;
using System.Linq;

namespace _02.Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                                   .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            string input;
            int targetHP = 0;
            int targetsDown = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(input);
                if (targetIndex > arr.Length - 1 || targetIndex < 0)// if target is invalid
                {
                    continue;
                }
                targetHP = arr[targetIndex];
                arr[targetIndex] = -1; // target is shot with -1 hp, we have the number to increase or decrease all other numbers 

                for (int i = 0; i < arr.Length; i++) // we go through all numbers in the array to increase or decrease hp 
                {
                    if (arr[i] == -1)
                        continue;
                    if (arr[i] > targetHP) // case that we decrease hp due that the number is higher than the target
                    {
                        arr[i] -= targetHP;
                    }
                    else if (arr[i] <= targetHP) //case where we increase the number due its being lower than the target hp
                    {
                        arr[i] += targetHP;
                    }
                }

            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                    targetsDown++;

            }
            Console.WriteLine($"Shot targets: {targetsDown} -> {string.Join(" ", arr)}");

        }
    }
}
