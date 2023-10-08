using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType;
            List<Animal> animals = new List<Animal>();
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];
                if (age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Cat":
                            Cat cat = new(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Kitten":
                            Kitten kitten = new(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(name, age);
                            animals.Add(tomcat);
                            break;
                    }
                }    
            }
            foreach (var animal in animals)
                Console.WriteLine(animal.ToString());
        }
    }
}
