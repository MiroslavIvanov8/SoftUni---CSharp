using System.Xml.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,List<double>> Students = new Dictionary<string,List<double>>();
            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!Students.ContainsKey(studentName))
                {
                    Students.Add(studentName, new List<double>());
                }
                Students[studentName].Add(grade);
            }
            double avgGrade = 0;
            
            foreach (var student in Students)
            {
                for (int i = 0; i < student.Value.Count; i++)
                {
                    avgGrade+= student.Value[i];
                }
                avgGrade/= student.Value.Count;
                if (avgGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {avgGrade:f2}");
                }
                avgGrade = 0;
            }
        }
    }
}