using System.Reflection;

namespace SpeedRaceCar
{

    public class StartUp
    {
        public static void Main()
        {
            List<Car> modelCars = new ();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                
                    modelCars.Add(car);
                
            }

            string driveCommand = string.Empty;

            while ((driveCommand = Console.ReadLine()) != "End")
            {
                string[] driveInfo = driveCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = driveInfo[1];
                double distance = double.Parse(driveInfo[2]);

                Car currCar = modelCars.Where(x => x.Model == carModel).ToList()[0]; ;                
                currCar.Drive(distance, currCar);
            }

            Console.WriteLine(string.Join(Environment.NewLine, modelCars));
        }
    }
}
    