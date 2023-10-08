namespace Vehicles
{
    internal class StartUp
    {
        static void Main()
        {
            List<Vehicle> vehicles = new();

            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmd[0];
                string currVehicle = cmd[1];
                double km = double.Parse(cmd[2]);

                if (currVehicle == "Car")
                {
                    if (cmdType == "Drive")
                    {
                        Console.WriteLine(car.Drive(km));
                    }
                    else if (cmdType == "Refuel")
                    {
                        car.Refuel(km);
                    }
                }
                else if (currVehicle == "Truck")
                {
                    if (cmdType == "Drive")
                    {
                        Console.WriteLine(truck.Drive(km));
                    }
                    else if (cmdType == "Refuel")
                    {
                        truck.Refuel(km);
                    }
                }
                else if (currVehicle == "Bus")
                {
                    if (cmdType == "DriveEmpty")
                    {
                        Console.WriteLine(bus.Drive(km));
                    }
                    else if (cmdType == "Drive")
                    {
                        Console.WriteLine(bus.DriveWithPeople(km));
                    }
                    else if (cmdType == "Refuel")
                    {
                        truck.Refuel(km);
                    }
                }
            }
            foreach(Vehicle currVehicle in vehicles)
            {  
                Console.WriteLine($"{currVehicle.GetType().Name}: {(currVehicle.FuelQuantity):f2}");
            }
        }
    }
}