﻿namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                char[] reversedWord = input.Reverse().ToArray();
                Console.WriteLine($"{input} = {string.Join("", reversedWord)}");
            }
        }
    }
}