using System;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int employeesUnite = employee1+ employee2 + employee3;
            int hourCounter = 0;

            while(students>=0) 
            {
                hourCounter++;                
                if (hourCounter % 4 == 0)
                {                   
                    continue;
                }
                if (students - employeesUnite < 0)
                    break;
                students-= employeesUnite;

                

            }
            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}
