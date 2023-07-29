using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMiltiplier = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => TigerWeightMiltiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => 
            new HashSet<Type> { typeof(Meat) };

        public override string ProduceSound() => "ROAR!!!";
    }
}
