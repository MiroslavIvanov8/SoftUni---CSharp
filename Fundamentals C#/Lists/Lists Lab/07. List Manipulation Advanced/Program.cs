using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split().ToArray();
                string cmdType = commandArgs[0];
                if (cmdType == "Contains")
                {   
                    int number = int.Parse(commandArgs[1]);
                    IfContains(numbers, number); // static void,returning yes or now
                }
                else if (cmdType == "PrintEven")
                {
                    PrintEven(numbers);
                    Console.WriteLine();
                }
                else if (cmdType == "PrintOdd")
                {
                    PrintOdd(numbers);
                    Console.WriteLine();
                }
                else if (cmdType == "GetSum")
                {
                    GetSum(numbers);
                }
                else if (cmdType=="Filter")
                {
                    string condition = commandArgs[1];
                    int number = int.Parse(commandArgs[2]);
                    FilterNumbers(numbers,number, condition);
                }
                        
            }
        }
        static void IfContains(List<int> numbers, int number)        
        { 
            bool doesContain =numbers.Contains(number);
            if (doesContain)
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No such number");
        }
        static void PrintEven(List<int> numbers)
        { 
            for(int i =0;i<numbers.Count;i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        static void PrintOdd(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        static void GetSum(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
        static void FilterNumbers(List<int> numbers, int number, string condition)
        {
            if (condition == "<")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < number)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > number)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= number)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= number)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
        }
    }
}
