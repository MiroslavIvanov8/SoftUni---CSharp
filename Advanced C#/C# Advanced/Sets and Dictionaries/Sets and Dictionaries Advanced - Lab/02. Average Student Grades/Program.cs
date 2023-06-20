namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string,List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                    
                }                
                    students[studentName].Add(grade);
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (decimal number in student.Value)
                {
                    Console.Write($"{number:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }    
        }
    }
}