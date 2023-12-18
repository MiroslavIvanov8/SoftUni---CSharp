using System;
using System.Linq;

namespace The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInQue = int.Parse(Console.ReadLine());
            int[] wagons =Console.ReadLine()
                                 .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int freeSeat = 0;
            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    freeSeat = 4 - wagons[i]; // free seats in each wagon
                                              // need to check if there are enough people \
                    if (freeSeat <= peopleInQue)
                    {
                        wagons[i] += freeSeat;
                        peopleInQue -= freeSeat;
                    }
                    // if free seats > people 
                    else 
                    {
                        freeSeat = peopleInQue;
                        wagons[i] += freeSeat;
                        peopleInQue-= freeSeat;
                    }
                    
                }
                if(peopleInQue==0)
                {
                    break;
                }
            }
            bool allTaken = true;
            if (peopleInQue == 0)
            { 
                for(int i=0;i<wagons.Length;i++)
                {
                    if (wagons[i] < 4)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(" ", wagons));
                        allTaken= false;
                        break;
                    }
                }
            }
            else if (peopleInQue > 0)
            {    allTaken = false;
                Console.WriteLine($"There isn't enough space! {peopleInQue} people in a queue!");
                Console.WriteLine(string.Join(" ",wagons));
            }
            if(peopleInQue==0 && allTaken)
                Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
