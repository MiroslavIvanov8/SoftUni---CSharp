using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string name, int quantity)
        {
            switch (name)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                    break;
                case "Fruit":
                    return new Fruit(quantity);
                    break;
                case "Meat":
                    return new Meat(quantity);
                    break;
                case "Seeds":
                    return new Seeds(quantity);
                    break;
                default:
                    return null;

            }
        }
    }
}
