using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
		private string model;
        private double fuelAmount; 
		private double fuelConsumptionPerKilometer;
        private double travelledDistance;
		public Car()
		{
			travelledDistance= 0.0;
		}
		public Car(string model,double fuelAmount,double fuelConsumption) : this() 
		{
			Model = model;
			FuelAmount = fuelAmount;
			FuelConsumptionPerKilometer= fuelConsumption;
		}
        public string Model
		{
			get { return model; }
			set { model = value; }
		}
			
		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}

		public double FuelConsumptionPerKilometer
        {
			get { return fuelConsumptionPerKilometer; }
			set { fuelConsumptionPerKilometer = value; }
		}		

		public double TravelledDistance
		{
			get { return travelledDistance; }
			set { travelledDistance = value; }
		}

		public void Drive(double distance,Car car)
		{
			double fuelNeeded = car.FuelConsumptionPerKilometer * distance;
			if (fuelNeeded <= car.fuelAmount)
			{
				car.fuelAmount -= fuelNeeded;
				car.TravelledDistance += distance;
			}
			else
				Console.WriteLine("Insufficient fuel for the drive");


        }


	}
}
