using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        protected abstract double WeightMultiplier { get; }
        protected abstract IReadOnlyCollection<Type> PrefferedFoodTypes { get; }
        
        public void Eat(IFood food)
        {
            if (!PrefferedFoodTypes.Any(ft=>food.GetType().Name == ft.Name))
            {
                throw new Exception($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
