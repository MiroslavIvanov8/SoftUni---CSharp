using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline, IFeline
    {
        private const double CatWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => CatWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes =>
            new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound() => "Meow";
    }
}
