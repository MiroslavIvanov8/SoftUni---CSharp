using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Person> people= new List<Person>();
            while((input=Console.ReadLine())!="End")
            {
                string[] inputInfo = input.Split(" ");
                string name = inputInfo[0];
                string id = inputInfo[1];
                int age = int.Parse(inputInfo[2]);
                bool sameStudent = false;
                Person person = new Person(name, id, age);

                foreach (Person human in people) // case where we have an existing id and we replace its data
                {
                    if (id == human.ID)
                    {
                        sameStudent = true;
                        break;
                    }
                    
                }
                if (sameStudent)
                {
                    foreach (Person human in people)
                    {
                        if (id == human.ID)
                        {
                            human.Name = name;
                            human.Age = age;
                            break;
                        }
                    }
                }
                else
                    people.Add(person);                
                
            }

            foreach (Person person in people.OrderBy(a=>a.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }    
        public string ID { get; set; }
        public int Age { get; set; }
    }


}