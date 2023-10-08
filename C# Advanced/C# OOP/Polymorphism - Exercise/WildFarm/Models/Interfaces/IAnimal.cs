using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {

        public string Name { get;  }
        public double Weight { get; }
        public int FoodEaten { get; }

        public string ProduceSound();
        void Eat(IFood food);
    }
}
