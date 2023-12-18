using System;

namespace _6._Foreign_Languages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day= Console.ReadLine();
            switch(day) 
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;


            }
        }
    }
}
