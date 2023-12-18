using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                                        .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split(" ");
                string commandType = commandArgs[0];
                int index = int.Parse(commandArgs[1]);
                if (commandType == "Shoot" && (index >=0 && index<targets.Count))
                {
                    int power = int.Parse(commandArgs[2]);
                    targets[index]-=power;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }


                }
                else if (commandType == "Add")
                {
                    int value = int.Parse(commandArgs[2]);
                    if (index < 0 || index > targets.Count) // if index is invalid
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }
                    else // in case its a valid index we insert it at the given position
                    {
                        targets.Insert(index, value);
                        continue;
                    }
                }
                else if (commandType == "Strike")
                {
                    int radius = int.Parse(commandArgs[2]);
                    if (index - radius < 0 || index + radius > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                    else
                    {
                        targets.RemoveRange(index-radius, (radius*2)+1);
                    }
                }
            }

            Console.WriteLine(string.Join("|",targets));
        }
    }
}
