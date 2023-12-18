using System;
using System.Net;

namespace _03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> list = input.Split().ToList();
            List<int> numbers = new List<int>(); // only numbers 
            
            for (int i = 0; i < input.Length; i++)
            {

                if (Char.IsDigit(input[i]))
                {
                    numbers.Add(input[i]);
                }                
            }
            string text = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()); // only text string
            
        }

        
    }
}