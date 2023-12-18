namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string,Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split("|");
                string carName = carInfo[0];
                int carMileage = int.Parse(carInfo[1]);
                int carFuel = int.Parse(carInfo[2]);

                Car car = new Car() {Mileage= carMileage, Fuel = carFuel};
                cars.Add(carName, car);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                //•	"Drive : {car} : {distance} : {fuel}":
                string[] commandArgs = command.Split(" : ");
                string carName = commandArgs[1];
                if (commandArgs[0] == "Drive")
                {
                    int distanceToDrive = int.Parse(commandArgs[2]);
                    int fuelNeeded = int.Parse(commandArgs[3]);
                    if (cars[carName].Fuel < fuelNeeded)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distanceToDrive;
                        cars[carName].Fuel -= fuelNeeded;
                        Console.WriteLine($"{carName} driven for {distanceToDrive} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }
                    if (cars[carName].Mileage>=100000)
                    { 
                        Console.WriteLine($"Time to sell the {carName}!");
                        cars.Remove(carName);
                    }
                }
                else if (commandArgs[0] == "Refuel")
                {
                    int fuel = int.Parse(commandArgs[2]);
                    if (cars[carName].Fuel + fuel > 75)
                    {
                        int diff = 75 - cars[carName].Fuel;                        
                        cars[carName].Fuel += diff;
                        Console.WriteLine($"{carName} refueled with {diff} liters");
                    }
                    else
                    {
                        cars[carName].Fuel += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                    
                }
                else if (commandArgs[0] == "Revert")
                {
                    int distanceToRevert = int.Parse(commandArgs[2]);
                    if (cars[carName].Mileage - distanceToRevert < 10000)
                    {
                        cars[carName].Mileage = 10000;
                    }
                    else
                    {
                        cars[carName].Mileage -= distanceToRevert;
                        Console.WriteLine($"{carName} mileage decreased by {distanceToRevert} kilometers");
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
        
        class Car
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}