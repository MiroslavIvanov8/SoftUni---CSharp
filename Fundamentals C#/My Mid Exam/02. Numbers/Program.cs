using System.Data;

namespace _02._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "Finish")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commanType = commandArgs[0];
                if (commanType == "Add")
                {
                    int value = int.Parse(commandArgs[1]);
                    numbers.Add(value);
                }
                else if (commanType == "Remove")
                {
                    int value = int.Parse(commandArgs[1]);
                    numbers.Remove(value);
                }
                else if (commanType == "Replace")
                {                                                 
                    int value = int.Parse(commandArgs[1]);                        // 0  1  2  3  4  5
                    if (numbers.Contains(value))                                 //  5  9 70 -56 9  9 
                    {
                        int replacement = int.Parse(commandArgs[2]);
                        int index = numbers.IndexOf(value);
                        numbers.RemoveAt(index);
                        numbers.Insert(index, replacement);
                    }
                }
                else if (commanType == "Collapse")
                {
                    int value = int.Parse(commandArgs[1]);
                    numbers.RemoveAll(x => x < value);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}