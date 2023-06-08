namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string,Car> modelCars= new Dictionary<string,Car>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model,fuelAmount,fuelConsumptionPerKilometer);
                if (!modelCars.ContainsKey(model))
                {
                    modelCars.Add(model,car);
                }
            }

            string driveCommand = string.Empty;

            while ((driveCommand = Console.ReadLine()) != "End")
            {
                string[] driveInfo = driveCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = driveInfo[1];
                double distance = double.Parse(driveInfo[2]);

                Car currCar = modelCars[carModel];

                currCar.Drive(distance, currCar);
            }
            foreach (var model in modelCars.OrderBy(m=>m.Key))
            {                
                Console.WriteLine($"{model.Key} {model.Value.FuelAmount:f2} {model.Value.TravelledDistance}");
            }
        }
    }
}