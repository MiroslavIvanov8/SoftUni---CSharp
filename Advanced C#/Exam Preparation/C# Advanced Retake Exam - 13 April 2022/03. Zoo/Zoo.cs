using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Zoo
{
    public class Zoo
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }
        public Zoo(string name, int capacity)
        {
            Name= name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
                return "Invalid animal species.";
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                return "Invalid animal diet.";
            else if (Animals.Count == Capacity)
                return "The zoo is full.";
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }            
        }
        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species);
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }
        public Animal GetAnimalByWeight(double weight)
        {            
            return Animals.First(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        { 
            List<Animal> searched = Animals.Where(x=>x.Length>=minimumLength && x.Length<=maximumLength).ToList();
            return $"There are {searched.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
