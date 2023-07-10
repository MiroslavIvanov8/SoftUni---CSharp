using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
		private double fuelQuantity;
		private double fuelConsumption;
		private double tankCapacity;

		public virtual double TankCapacity
		{
			get { return tankCapacity; }
			set { tankCapacity = value; }
		}


		public virtual double FuelConsumption
		{
			get { return fuelConsumption; }
			set { fuelConsumption = value; }
		}


		public virtual double FuelQuantity
		{
			get { return fuelQuantity; }
			set { fuelQuantity = value; }
		}

		public abstract string Drive(double km);
		public abstract string DriveWithPeople(double km);
		public virtual void Refuel(double fuel)
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
            FuelQuantity += fuel;
        }
	}
}
