using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split().ToArray();
                string cmdType = commandArgs[0];
                if (cmdType == "Add")
                {
                    int number = int.Parse(commandArgs[1]);
                    numbers.Add(number);
                }
                else if (cmdType == "Remove")
                {
                    int number = int.Parse(commandArgs[1]);
                    numbers.Remove(number);
                }
                else if (cmdType == "RemoveAt")
                {
                    int index = int.Parse(commandArgs[1]);
                    numbers.RemoveAt(index);
                }
                else if (cmdType == "Insert")
                {
                    int number = int.Parse(commandArgs[1]);
                    int index = int.Parse((string)commandArgs[2]);
                    numbers.Insert(index, number);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        
    }
}
