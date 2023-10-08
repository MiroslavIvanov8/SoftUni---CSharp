using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> greys = new(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray());
            
            Dictionary<string, int> newFormedTiles = new Dictionary<string, int>()
                 {
                ["Countertop"] = 0,
                ["Floor"] = 0,
                ["Oven"] = 0,
                ["Sink"] = 0,
                ["Wall"] = 0
                 };

            while(whites.Any() && greys.Any()) 
            {

                if (whites.Peek() == greys.Peek())
                {
                    int newTile = whites.Pop() + greys.Dequeue();

                    if (newTile == 40)
                    {
                        newFormedTiles["Sink"]++;
                    }
                    else if (newTile == 50)
                    {
                        newFormedTiles["Oven"]++;
                    }
                    else if (newTile == 60)
                    {
                        newFormedTiles["Countertop"]++;
                    }
                    else if (newTile == 70)
                    {
                        newFormedTiles["Wall"]++;
                    }
                    else
                    {
                        newFormedTiles["Floor"]++;
                    }
                }
                else
                {
                    whites.Push(whites.Pop() / 2);
                    greys.Enqueue(greys.Dequeue());
                }
                
            }
            if (whites.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whites)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greys.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greys)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var tile in newFormedTiles.Where(x => x.Value != 0).OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}
