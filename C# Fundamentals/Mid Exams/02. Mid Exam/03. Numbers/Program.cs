using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            input.Sort();
            input.Reverse();
            double averageNum = 0;
            
            List<int> TopNumbers =new List<int>();
           averageNum= input.Average();
            for(int i=0;i<input.Count;i++)
            {
                
                if (input[i] > averageNum)
                {
                    TopNumbers.Add(input[i]);
                }
            }
             TopNumbers.OrderByDescending(x => x).ToList();
            if(TopNumbers.Count > 5)
            {
                TopNumbers.RemoveRange(5, TopNumbers.Count - 5);
            }
            if (TopNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else 
            { 
                Console.WriteLine(string.Join(" ", TopNumbers));
            }
        }
    }
}
