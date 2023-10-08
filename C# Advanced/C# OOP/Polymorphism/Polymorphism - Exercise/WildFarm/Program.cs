using WildFarm.Core;
using WildFarm.Core.Interfaces;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();
            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Run();
        }
    }
}