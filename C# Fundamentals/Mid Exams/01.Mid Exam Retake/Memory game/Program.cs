using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)                                        
                                        .ToList();
            string input;
            int counter = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                counter++;
                string[] inputAsString = input
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();
                int firstIndex = int.Parse(inputAsString[1]);
                int zeroIndex = int.Parse(inputAsString[0]);
                if (zeroIndex == firstIndex || zeroIndex < 0 || zeroIndex > numbers.Count - 1 || firstIndex < 0 || firstIndex > numbers.Count-1)
                {
                    //"-{number of moves until now}a"
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string addition = "-" + counter + "a";
                    numbers.Insert(numbers.Count / 2, addition);
                    numbers.Insert(numbers.Count / 2, addition); 
                    continue;
                }
                if (numbers[zeroIndex] == numbers[firstIndex]) // case that player makes a match
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {numbers[0]}!");
                    string toDelete = numbers[zeroIndex];
                    numbers.Remove(toDelete); 
                    numbers.Remove(toDelete);
                    

                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"You have won in {counter} turns!");
                        break;
                    }
                    continue;

                }
                if (numbers[zeroIndex] != numbers[firstIndex])
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
                
            }
            if (numbers.Count - 1 > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
