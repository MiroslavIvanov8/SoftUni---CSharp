using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            string input;
            while ((input = Console.ReadLine()) != "Craft")
            {
                string[] commandArgs = input.Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];
                if (commandType == "Collect ")
                {
                    string item = commandArgs[1];
                    if (items.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(item);
                    }

                }
                else if (commandType == "Drop")
                {
                    string item = commandArgs[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (commandType == "Combine Items")
                {
                    string[] itemsInfo = commandArgs[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = itemsInfo[0];
                    string newItem = itemsInfo[1];

                    if (items.Contains(oldItem))
                    {
                        int indexOfOldItem = items.IndexOf(oldItem);
                        items.Insert(indexOfOldItem + 1, newItem);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commandType == "Renew")
                {
                    string item = commandArgs[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
