﻿namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            PrintNumber(inputNum);
        }
        static void PrintNumber(int num)
        {
            for(int i =0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(num+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}