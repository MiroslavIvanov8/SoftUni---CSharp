using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeghtMultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
           
        }

        protected override double WeightMultiplier => DogWeghtMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes =>
            new HashSet<Type> {typeof(Meat) };

        public override string ProduceSound() => "Woof";
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
