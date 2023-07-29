using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IFoodFactory foodFactory { get;}
        private IAnimalFactory animalFactory { get;}
        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory )
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }
        public void Run()
        {
            string cmd;
            int lineCnt = 0;

            List<IAnimal> animals = new();

            IAnimal currAnimal = null;
            IFood currFood = null;

            while ((cmd = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (lineCnt % 2 == 0) // create animal
                    {
                        lineCnt++;
                        IAnimal animal = animalFactory.Create(cmdArgs);

                        animals.Add(animal);

                        currAnimal = animal;

                    }
                    else // create food
                    {
                        lineCnt++;
                        string foodName = cmdArgs[0];
                        int quantity = int.Parse(cmdArgs[1]);

                        currFood = foodFactory.CreateFood(foodName, quantity);

                        Console.WriteLine(currAnimal.ProduceSound());


                        currAnimal.Eat(currFood);



                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            foreach (var animal in animals)
                Console.WriteLine(animal);
        }
    }
}
