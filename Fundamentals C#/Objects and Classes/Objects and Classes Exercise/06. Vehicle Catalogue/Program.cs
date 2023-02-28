namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            string info;
            while ((info = Console.ReadLine()) != "End")
            {
                string[] infoArgs = info.Split(" ");
                string type = infoArgs[0];
                if (type == "car")
                {
                    string typeoOfCar = "Car";
                    string model = infoArgs[1];
                    string color = infoArgs[2];
                    double horsePower = double.Parse(infoArgs[3]);
                    Car car = new Car(type, model, color, horsePower);
                    cars.Add(car);
                }
                else
                {
                    string typeOfTruck = "Truck";
                    string model = infoArgs[1];
                    string color = infoArgs[2];
                    double horsePower = double.Parse(infoArgs[3]);
                    Truck truck  = new Truck (type, model, color, horsePower);
                    trucks.Add(truck);
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach(Car car in cars )
                {
                    if (input == car.Model)
                    {
                        Console.WriteLine($"Type: Car");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }
                foreach (Truck truck in trucks)
                {
                    if (input == truck.Model)
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {truck.Model}");
                        Console.WriteLine($"Color: {truck.Color}");
                        Console.WriteLine($"Horsepower: {truck.HorsePower}");
                    }
                }
            }
            double carsHorsePower = 0;
            double trucksHorsePower = 0;
            foreach (Car car in cars)
            {
                carsHorsePower+= car.HorsePower;
            }
            foreach (Truck truck in trucks)
            {
                trucksHorsePower+= truck.HorsePower;
            }

            if (cars.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {carsHorsePower / cars.Count:f2}.");
            }
            if (trucks.Count == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucksHorsePower / trucks.Count:f2}.");
            }

        }
    }
    class Vehicle
    {
        
    }
    class Car
    {
        public Car(string typeOfCar, string model, string color, double horsePower)        {
            Type = typeOfCar;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }


        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

    }
    class Truck
    {
        public Truck(string typeOfTruck, string model, string color, double horsePower)
        {
            Type = typeOfTruck;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
       public string Type { get; set; }
       public string Model { get; set; }
       public string Color { get; set; }
       public double HorsePower { get; set; }
    }
}