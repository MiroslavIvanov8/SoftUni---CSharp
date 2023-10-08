using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            
            string command = string.Empty;

            List<Tire[]> tires = new();
            
            while ((command = Console.ReadLine()) != "No more tires")
            {
                
                double[] tireInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(double.Parse)
                                           .ToArray();

                Tire[] Tire = new Tire[4];
                int cnt = 0;
                for (int i = 0; i < tireInfo.Length; i++)
                {
                    if (i % 2 != 0)
                        continue;

                    int year = (int)tireInfo[i];
                    double pressure = tireInfo[i + 1];
                    Tire currTire = new Tire(year, pressure);
                    Tire[cnt++]= currTire;
                }
                tires.Add(Tire);
            }

            List<Engine> engines = new List<Engine>();
            string engineCommand = string.Empty;

            while ((engineCommand = Console.ReadLine()) != "Engines done")
            {
                double[] enginesInfo = engineCommand.Split(" ",StringSplitOptions.RemoveEmptyEntries).
                    Select(double.Parse)
                    .ToArray();
                Engine engine = new Engine((int)enginesInfo[0], enginesInfo[1]);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            string carCommand = string.Empty;

            while ((carCommand = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = carCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    FuelQuantity = fuelQuantity,
                    FuelConsumption = fuelConsumption,
                    Engine = engines[engineIndex],
                    Tires = tires[tireIndex]                   
                 };
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double pressureSum = 0;
                    foreach(Tire tire in car.Tires)
                        pressureSum += tire.Pressure;
                    if (pressureSum >= 9 && pressureSum <= 10)
                    {
                        car.Drive(20.0/100);
                        Console.WriteLine($"Make: {car.Make}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Year: {car.Year}");
                        Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                        Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                    }


                }


            }
        }
    }
}