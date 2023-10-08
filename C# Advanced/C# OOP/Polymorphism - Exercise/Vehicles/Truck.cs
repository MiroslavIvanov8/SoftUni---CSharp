using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 1.6;           
        }

        public override double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public override double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public override double FuelQuantity
        {
            get
            { 
                return fuelQuantity;
            }
            set
            { 
                if (value > TankCapacity)
                    value = 0;
                fuelQuantity = value;
            }
        }

        public override string Drive(double km)
        {
            if (fuelQuantity < fuelConsumption * km)
            {
                return $"{this.GetType().Name} needs refueling";
            }            
            fuelQuantity -= km * fuelConsumption;
            return $"{this.GetType().Name} travelled {km} km";
        }

        public override string DriveWithPeople(double km)
        {
            throw new NotImplementedException();
        }
        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            double availableSpace = TankCapacity - FuelQuantity;

            if (Math.Abs(availableSpace) < fuel)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            FuelQuantity += fuel * 0.95;
        }
    }
}
