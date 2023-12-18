using static System.Formats.Asn1.AsnWriter;
using System.Numerics;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while((command= Console.ReadLine())!="Travel")
            {
                string[] commandArgs = command.Split(":");
                if (commandArgs[0]== "Add Stop")
                {
                    int index = int.Parse(commandArgs[1]);
                    string addition = commandArgs[2];
                    if (index < 0 || index > input.Length)
                    {
                        Console.WriteLine(input);
                        continue;
                    }
                    else
                    {
                        input = input.Insert(index, addition);
                        Console.WriteLine(input);
                    }
                }
                else if (commandArgs[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    int count = endIndex - startIndex;

                    if (startIndex < 0 || startIndex + count  > input.Length - 1)
                    {
                        Console.WriteLine(input);
                        continue;
                    }
                    else
                    {
                        input = input.Remove(startIndex, count+1);
                        Console.WriteLine(input);
                    }

                }
                else if (commandArgs[0]== "Switch") 
                {
                    string oldString = commandArgs[1];
                    string newString = commandArgs[2];
                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine(input);
                        continue;
                    }
                    
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
            
        }
    }
}