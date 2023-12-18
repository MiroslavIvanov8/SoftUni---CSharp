using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for(int i =0; i < n; i++)
            {
                
                string []input = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();
                string name = input[0];
                if (input.Length == 3)
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                        guests.Add(name);
                }
                else if (input.Length == 4)
                {
                    if (!guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                        guests.Remove(name);  
                }               
               
            }
            Console.WriteLine(string.Join(Environment.NewLine,guests));
        }
    }
}
