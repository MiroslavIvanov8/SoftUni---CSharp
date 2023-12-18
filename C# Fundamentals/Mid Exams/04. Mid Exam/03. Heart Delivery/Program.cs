using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses =Console.ReadLine()
                                      .Split("@")
                                      .Select(int.Parse)
                                      .ToList();
            int currIndex = 0;
            string input;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split(" ");
                int jumpLenght = int.Parse(command[1]);
                currIndex += jumpLenght;

                if (currIndex> houses.Count - 1) // case where the cupid jumps outside the list and returns to [0]position
                {
                    currIndex = 0;
                    if (houses[currIndex] == 0) // case the needed hearts were already 0 
                    {
                        Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                        continue;
                    }
                    else // case where the hearts needed were more than 0 
                    {
                        houses[currIndex] -= 2;
                        if (houses[currIndex] == 0)
                        {
                            Console.WriteLine($"Place {currIndex} has Valentine's day.");
                            continue;
                        }
                        else 
                            continue;
                    }
                }
                if (currIndex <= houses.Count - 1)
                {
                    if (houses[currIndex] == 0) // case the needed hearts were already 0 
                    {
                        Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                        continue;
                    }
                    else // case where the hearts needed were more than 0 
                    {
                        houses[currIndex] -= 2;
                        if (houses[currIndex] == 0)
                        {
                            Console.WriteLine($"Place {currIndex} has Valentine's day.");
                            continue;
                        }
                        else
                            continue;
                    }
                }                
            }
            Console.WriteLine($"Cupid's last position was {currIndex}.");
            int counter = houses.Count;
            for(int i=0;i<houses.Count;i++)
            {
                if (houses[i] == 0)
                {
                    counter--;
                }
            }
            if (counter == 0)
                Console.WriteLine("Mission was successful.");
            else
                Console.WriteLine($"Cupid has failed {counter} places.");



        }
    }
}
