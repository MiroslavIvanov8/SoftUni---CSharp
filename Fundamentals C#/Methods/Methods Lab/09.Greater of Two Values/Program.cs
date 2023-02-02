using System;

namespace _09.Greater_of_Two_Values
{
    internal class Program    {

        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int greaterValue = GetMax(a, b);
                Console.WriteLine(greaterValue);
            }
            else if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string greaterValue = (string)GetMax(a, b);
                Console.WriteLine(greaterValue);
            }
            else if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                char greaterValue = (char)GetMax(a, b);
                Console.WriteLine(greaterValue);
            }            
        }
        static int GetMax(int a, int b)
        {
            if (a > b)
                return a;

            return b;
        }
        static string GetMax(string a, string b)
        {
            int result = a.CompareTo(b);
            if (result > 0)
                return a;

            return b;


        }
        static char GetMax(char a, char b)
        {
            if (a > b)
                return a;

            return b;
        }
    }
}
