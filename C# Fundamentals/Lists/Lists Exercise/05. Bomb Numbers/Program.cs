using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] bombDetails = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bomb = bombDetails[0];
            int bombStrenght = bombDetails[1];         
            int bombIndex = numbers.IndexOf(bomb);
            int start = bombIndex - bombStrenght;
            int end = bombIndex + bombStrenght;
            //1 2 2 4 2 2 2 9
            //4 2

            //if (start < 0)
            //    start = 0;
            //for (int i = start; i <bombIndex; i++)
            //{
            //    numbers.Remove(numbers[i]);
            //}
            //if (end > numbers.Count - 1)
            //    end = numbers.Count - 1;
            //for (int i = bombIndex; i < end; i++)
            //{
            //    numbers.Remove(numbers[i]);
            //}









            int start = bombIndex - bombStrenght;                           
            int end = bombIndex + bombStrenght;
            if (end > numbers.Count - 1)
            {
                end = numbers.Count - 1;
            }
            else if (start > bombIndex)             
            {
                start = 0;
            }
            for (int i = 0;i < numbers.Count;i++)
            {
                if (numbers[i]==bomb)
                numbers.RemoveRange(start, end - start +1);
            }
            
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
            
 
        }
    }
}
