using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 0.9;

        }
        public override double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }
        
        public override double FuelConsumption
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
            if (fuelQuantity < km * fuelConsumption)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            fuelQuantity -= km* fuelConsumption;
            return $"{this.GetType().Name} travelled {km} km";
        }        

        public override string DriveWithPeople(double km)
        {
            throw new NotImplementedException();
        }
    }
}
