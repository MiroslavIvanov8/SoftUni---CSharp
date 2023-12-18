namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] StudenInfo = input.Split(" ");
                string firstName = StudenInfo[0];
                string lastName = StudenInfo[1];
                int age = int.Parse(StudenInfo[2]);
                string town = StudenInfo[3];
                bool isStudentExisting = false;

                foreach (Student student in students)
                {
                    if (student.FirstName == firstName && student.LastName == lastName) // we go through all the students to check if we have a match
                    {
                        isStudentExisting = true;
                        break;
                    }
                }
                if (isStudentExisting) // case where we have an existing student we have to override the data
                {
                    foreach (Student student in students)
                    {
                        if (student.FirstName == firstName && student.LastName == lastName) // we go through all the students to check if we have a match
                        {
                            student.Age = age;
                            student.HomeTown = town;
                        }
                    }
                }
                else  // case where we need to create a new student info
                {
                    Student student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = town

                    };
                    students.Add(student);
                }

            }
            string cityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (cityName == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }

}