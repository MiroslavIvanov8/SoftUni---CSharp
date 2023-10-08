using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[]info)
        {
            string type = info[0];
            string name = info[1];
            double weight = double.Parse(info[2]);
           
            switch (type)
            {
                case "Dog":
                    return new Dog(name, weight, info[3]);
                case "Mouse":
                    return new Mouse(name, weight, info[3]);                    
                case "Owl":
                    return new Owl(name, weight, double.Parse(info[3]));
                case "Hen":
                    return new Hen(name, weight, double.Parse(info[3]));
                case "Cat":
                    return new Cat(name, weight, info[3], info[4]);
                case "Tiger":
                    return new Tiger(name, weight, info[3], info[4]);
                default:
                    return null;
            }
        }

        
    }
}
