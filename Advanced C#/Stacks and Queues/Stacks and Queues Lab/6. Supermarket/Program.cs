﻿namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                    queue.Enqueue(command);
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}