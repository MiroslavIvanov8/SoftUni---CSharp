using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                                            .Split("!")
                                            .ToList();
            string input;
            while ((input = Console.ReadLine())!= "Go Shopping!")
            {
                string[]commandArgs = input.Split(" ");
                string commandType = commandArgs[0];
                if (commandType == "Urgent" || commandType == "Unnecessary" || commandType == "Rearrange")
                {
                    string product = commandArgs[1];
                    if (commandType == "Urgent")
                    {
                        if (groceries.Contains(product))
                        {
                            continue;
                        }
                        else
                        {
                            groceries.Insert(0, product);
                        }
                    }
                    else if (commandType == "Unnecessary")
                    {
                        if (groceries.Contains(product))
                        {
                            groceries.Remove(product);                           
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (commandType == "Rearrange")
                    {
                        if (groceries.Contains(product))
                        {
                            groceries.Remove(product);
                            groceries.Add(product);
                        }
                        else
                            continue;
                    }
                }
                else if (commandType == "Correct")
                {
                    
                    string oldProduct = commandArgs[1];
                    string newProduct = commandArgs[2];
                    if (groceries.Contains(oldProduct))
                    {
                        int index = groceries.IndexOf(oldProduct);
                        groceries[index] = commandArgs[2];
                    }
                    else
                        continue;
                }
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
