using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                 .Split('|')
                 .ToList();
            string input;
            double sum = 0;
            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> commandArgs = input.Split(" ").ToList();
                string commandType = commandArgs[0];
                if (commandType == "Loot")
                {
                    for(int i =1;i<commandArgs.Count;i++)
                    {
                        if (!items.Contains(commandArgs[i]))
                        {
                            items.Insert(0,commandArgs[i]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (commandType == "Drop")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index < 0 || index > items.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(items[index]);
                        items.RemoveAt(index);                        
                    }

                }
                else if (commandType == "Steal")
                {
                    List<string> stolenItems = new List<string>();
                    int index = int.Parse(commandArgs[1]);
                    int start = items.Count - index;
                    if (start + index > items.Count||start<0)
                    {
                        start = 0;
                        index = items.Count;
                        for (int i = items.Count - index; i < items.Count; i++)
                        {
                            stolenItems.Add(items[i]);
                        }
                    }
                    else
                    {
                        for (int i = items.Count - index; i < items.Count; i++)
                        {
                            stolenItems.Add(items[i]);
                        }
                    }
                    items.RemoveRange(start, index);
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
                if (items.Count == 0)
                {
                    Console.WriteLine("Failed treasure hunt.");
                    break;
                }
            }
            if (items.Count > 0)
            {
                for(int i =0;i<items.Count;i++)
                {
                    sum += items[i].Length;
                }
                sum/=items.Count;
                Console.WriteLine($"Average treasure gain: {sum:f2} pirate credits.");
            }
        }
    }
}
