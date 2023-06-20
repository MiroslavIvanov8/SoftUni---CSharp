namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Family family = new Family()
            {
                People = new List<Person>() 
            };
            for (int i = 0; i < number; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name,age);
                family.AddMember(person);
            }
            foreach (var person in family.People.OrderBy(p=>p.Name).ThenBy(p=>p.Age))
            {
                if(person.Age > 30)
                Console.WriteLine($"{person.Name} - {person.Age}");
            }


        }
    }
}