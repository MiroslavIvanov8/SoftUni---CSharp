namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string,List<string>> courses= new Dictionary<string,List<string>>();
            while((input=Console.ReadLine())!="end")
            {
                string[] info =input.Split(" : ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = info[0];
                string studentName = info[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName,new List<string>());
                }
                courses[courseName].Add(studentName);                
            }
            foreach (var course in courses)
            {
                
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }

        }
    }
}