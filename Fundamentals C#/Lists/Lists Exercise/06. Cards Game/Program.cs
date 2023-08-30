using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                                     .Split(" ",StringSplitOptions.RemoveEmptyEntries)    
                                     .Select(int.Parse)
                                     .ToList();
            List<int> secondHand = Console.ReadLine()
                                     .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            int sum = 0;
            while (true)
            {
                for (int i = 0; i < firstHand.Count; i++)
                {
                    if (firstHand.Sum() == 0)
                    {
                        sum = secondHand.Sum();
                        Console.WriteLine($"Second player wins! Sum: {sum}");
                        return;
                    }
                    if (secondHand.Sum() == 0)
                    {
                        sum = firstHand.Sum();
                        Console.WriteLine($"First player wins! Sum: {sum}");
                        return;
                    }

                    if (firstHand[i] > secondHand[i])
                    {
                        firstHand.Add(secondHand[i]);
                        firstHand.Add(firstHand[i]);

                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }
                    else if (secondHand[i] > firstHand[i])
                    {
                        secondHand.Add(firstHand[i]);
                        secondHand.Add(secondHand[i]);

                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }
                    else
                    {
                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }
                }
            }



        }
    }
}
