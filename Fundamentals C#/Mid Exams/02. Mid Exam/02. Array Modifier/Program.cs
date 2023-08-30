using System;
using System.Buffers;
using System.Linq;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string input;
            while ((input =Console.ReadLine())!="end")
            {
                string[] commandArgs = input.Split();
                string commandType = commandArgs[0];

                if (commandType == "swap")
                {
                    int index1 = int.Parse(commandArgs[1]);
                    int index2 = int.Parse(commandArgs[2]);
                    int token = arr[index1];
                    arr[index1] = arr[index2];
                    arr[index2] = token;
                    
                }
                else if (commandType == "multiply")
                {
                    int index1 = int.Parse(commandArgs[1]);
                    int index2 = int.Parse(commandArgs[2]);
                    arr[index1] *= arr[index2];
                }
                else if (commandType == "decrease")
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= 1;
                    }

                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}

