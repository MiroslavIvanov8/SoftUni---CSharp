using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> wagons = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while(input != "end")
            {
                //•	Add {passengers} – add a wagon to the end of the train with the given number of passengers.
                //•passengers} – find a single wagon to fit all the incoming passengers(starting from the first wagon).
                string [] command = input.Split(" ");

                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    int passengers = int.Parse(command[0]);
                    //int wagon= wagons.First(x => x + passengers <= maxCapacity);
                    //wagons[wagons.IndexOf(wagon)] += passengers;
                       
                    //foreach(var wagon in wagons)
                    //{
                    //    if (wagons[wagon] + passengers <= maxCapacity)
                    //    {
                    //        wagons[wagons.IndexOf(wagon)] += passengers;
                    //        break;
                    //    }
                    //}

                   for(int i =0;i<wagons.Count;i++)
                   {
                       if (wagons[i] + passengers <= maxCapacity)
                       {
                           wagons[i] += passengers;
                           break;
                       }
                   }
                }

                input = Console.ReadLine(); 
                
            }
            
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
