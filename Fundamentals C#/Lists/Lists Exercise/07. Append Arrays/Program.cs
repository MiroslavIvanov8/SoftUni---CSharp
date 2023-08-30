using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] collectiveArray = Console.ReadLine().Split('|').ToArray();
            
            List<string> ReversedList = new List<string>();

            for (int i = collectiveArray.Length - 1; i >= 0; i--)
            {
                List<string> currList = collectiveArray[i]
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToList(); // removing all " "

                for (int j = 0; j < currList.Count; j++)
                {
                    ReversedList.Add(currList[j]);
                }
            }           
            
            Console.WriteLine(string.Join(" ", ReversedList));

        }
    }
}
