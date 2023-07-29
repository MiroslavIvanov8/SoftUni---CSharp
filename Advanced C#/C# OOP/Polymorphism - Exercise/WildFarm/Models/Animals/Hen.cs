using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double OwlWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) :
            base(name, weight, wingSize)
        {

        }
        protected override double WeightMultiplier => OwlWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes =>
            new HashSet<Type> {typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable), };

        public override string ProduceSound() => "Cluck";
    }
}
