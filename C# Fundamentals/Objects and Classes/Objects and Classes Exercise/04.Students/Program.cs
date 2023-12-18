using System.Collections.Generic;
using System.Diagnostics;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);


                Student currStudent = new Student()
                {
                    FirstName= firstName,
                    LastName= lastName,
                    Grade= grade,
                };
                students.Add(currStudent);
            }
            foreach (Student student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }

        }
    }

      
    class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

    }
}