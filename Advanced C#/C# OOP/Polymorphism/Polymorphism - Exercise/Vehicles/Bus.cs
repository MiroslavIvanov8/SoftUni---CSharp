using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;            
        }

        public override double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public  double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public override double FuelQuantity
        {
            get
            { 
                return fuelQuantity;
            }
            set 
            {
                if (value > tankCapacity)
                    value = 0;
                fuelQuantity = value;
            }
        }

        public override string Drive(double km)
        {
            //empty
            if (fuelQuantity < km * fuelConsumption)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            fuelQuantity -= km * fuelConsumption;

            return $"{this.GetType().Name} travelled {km} km";
        }
        public override string DriveWithPeople(double km)
        {
            //with people
            FuelConsumption += 1.4;
            if (FuelQuantity < km * FuelConsumption)
            {
                FuelConsumption -= 1.4;
                return $"{this.GetType().Name} needs refueling";
            }

            fuelQuantity -= km * fuelConsumption;
            FuelConsumption -= 1.4;

            return $"{this.GetType().Name} travelled {km} km";
        }
    }
}
