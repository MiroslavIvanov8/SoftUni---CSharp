using System;
using System.Collections.Generic;

namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int mistake = 0;

            while (mistake < 3)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (cmdArgs[0] == "Replace")
                    {
                        int index = int.Parse(cmdArgs[1]);
                        int element = int.Parse(cmdArgs[2]);

                        if (index < 0 || index > numbers.Length)
                        {

                            throw new IndexOutOfRangeException("The index does not exist!");
                        }

                        numbers[index] = element;
                    }


                    else if (cmdArgs[0] == "Print")
                    {
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);

                        List<int> toPrint = new();

                        if (startIndex < 0 || endIndex > numbers.Length - 1)
                        {

                            throw new IndexOutOfRangeException();
                        }
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            toPrint.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", toPrint));
                    }


                    else if (cmdArgs[0] == "Show")
                    {

                        int index = int.Parse(cmdArgs[1]);

                        if (index < 0 || index > numbers.Length)
                        {

                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine(numbers[index]);
                    }
                }

                catch (IndexOutOfRangeException)
                {
                    mistake++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    mistake++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }



    }
}