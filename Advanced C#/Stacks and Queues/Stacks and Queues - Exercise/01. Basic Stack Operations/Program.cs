namespace _01._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        

        static void Main(string[] args)
        {
            int[]info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int n = info[0];
            int toPop = info[1];
            int ifContains = info[2];
            int[] nNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                stack.Push(nNumbers[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
                Console.WriteLine(0);
            else if (stack.Contains(ifContains))
                Console.WriteLine("true");
            else if (!stack.Contains(ifContains))
            {
                int smallestElement = int.MaxValue;
                foreach (int number in stack)
                { 
                    if (number < smallestElement)
                        smallestElement= number;
                }
                Console.WriteLine(smallestElement);
            }
        }
    }
}