using System;
using System.ComponentModel;

namespace CarSalesMan
{
    public class StartUp
    {   
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Engine> engines = new();
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                int displacement = 0;
                string efficiency = null;
                
                if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int ParseDdisplacement))
                    {
                        displacement = ParseDdisplacement;
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                     displacement = int.Parse(engineInfo[2]);
                     efficiency = engineInfo[3];
                    
                }
                
                Engine engine = new Engine
                {
                    Model = model,
                    Power = power,
                    Displacement = (int)displacement,
                    Efficiency = efficiency
                };
                engines[engine.Model] = engine;
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];
                int weigth = 0;
                string color = null;

                if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int ParsedWeigth))
                    {
                        weigth = ParsedWeigth;
                    }
                    else
                    {
                        color = carInfo[2];
                    }
                }
                else if (carInfo.Length == 4)
                {
                    weigth = int.Parse(carInfo[2]);
                    color = carInfo[3];
                }
                Car car = new Car
                {
                    Model = model,
                    Engine = engines[engineModel],
                    Weigth = weigth,
                    Color = color,
                };
                cars.Add(car);
            }
            foreach (Car car in cars)
            {
                    Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($"  {car.Engine.Model}:");
                    Console.WriteLine($"     Power: {car.Engine.Power}");
                if(car.Engine.Displacement  ==  0)
                    Console.WriteLine($"     Displacement: n/a");
                else
                    Console.WriteLine($"     Displacement: {car.Engine.Displacement}");
                if (car.Engine.Efficiency == null)
                    Console.WriteLine($"     Efficiency: n/a");
                else
                    Console.WriteLine($"     Efficiency: {car.Engine.Efficiency}");
                if(car.Weigth == 0)
                    Console.WriteLine($"  Weight: n/a");
                else
                    Console.WriteLine($"  Weight: {car.Weigth}");
                if(car.Color == null)
                    Console.WriteLine($"  Color: n/a");
                else
                    Console.WriteLine($"  Color: {car.Color}");

            }
        }
    }
}