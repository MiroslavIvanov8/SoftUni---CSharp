using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            string input;
            while((input=Console.ReadLine()) != "End")
            {
                string[] command =input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string commandType = command[0];
                if (commandType == "Add")
                {
                    int number = int.Parse(command[1]);
                    numbersList.Add(number);
                }
                else if (commandType == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index < 0 || index >= numbersList.Count)
                    {
                        Console.WriteLine("Invalid index.");
                        continue;
                    }
                    else
                    {
                        numbersList.Insert(index, number);
                    }
                }
                else if (commandType == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index < 0 || index >= numbersList.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }    
                    numbersList.RemoveAt(index);
                }
                else if (commandType=="Shift")
                {
                    string direction = command[1];
                    int count = int.Parse(command[2]);          
                    if (direction == "left")                //1 23 29 18 43 21 20
                    {
                        for(int i =0;i<count;i++)
                        {
                            int firstNumber = numbersList[0];
                            numbersList.RemoveAt(0);
                            numbersList.Add(firstNumber);
                        }
                        
                    }
                    else if (direction == "right")
                    { 
                        int lastNumber =numbersList[numbersList.Count - 1];
                        numbersList.RemoveAt(numbersList.Count-1);
                        numbersList.Insert(0,lastNumber);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbersList));

        }  
    }
}
