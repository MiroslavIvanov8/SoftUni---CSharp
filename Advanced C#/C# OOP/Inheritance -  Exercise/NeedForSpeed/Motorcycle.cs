using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower,double fuel) : base(horsePower, fuel)
        {

        }
    }
    public class RaceMotorCycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;
        public RaceMotorCycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double FuelConsumption => DefaultFuelConsumption;

    }
    public class CrossMotorCycle : Motorcycle
    {
        public CrossMotorCycle(int horsePower, double fuel) : base (horsePower, fuel)
        {
                
        }
    }
}
