using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputInfo = input.Split("/");
                string type = inputInfo[0];
                string brand = inputInfo[1];
                string model = inputInfo[2];
                double data = double.Parse(inputInfo[3]);

                if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = data,
                        
                    };
                    cars.Add(car);
                }

                else
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = data,
                    };
                    trucks.Add(truck);
                }
            }
            
            Console.WriteLine("Cars:");
            foreach (Car car in cars.OrderBy(x=>x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                
            }
            Console.WriteLine("Trucks:");
            foreach (Truck truck in trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
        
    }
    //class Catalog
    //{
    //    public List CollectionOfTrucksAndCars { get; set; }
    //}

}