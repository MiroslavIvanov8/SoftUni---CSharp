using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3; 
        
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }
        public override double FuelConsumption => DefaultFuelConsumption;       
        
    }
    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
