using System;

namespace Basic_Syntax__Conditional_Statements_and_Loops___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int.TryParse(input, out int age);


            if (age >= 0 && age <= 2)            
                Console.WriteLine("baby");
            if (age > 2 && age <= 13)
                Console.WriteLine("child");
            if (age > 13 && age <= 19)
                Console.WriteLine("teenager");
            if (age > 19 && age <= 65)
                Console.WriteLine("adult");
            if (age > 65)
                Console.WriteLine("elder");           
        }
    }
}
