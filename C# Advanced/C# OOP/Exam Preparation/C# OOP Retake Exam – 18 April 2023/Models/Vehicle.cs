using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;        

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            LicensePlateNumber = licensePlateNumber;
            MaxMileage = maxMileage;
            IsDamaged = false;
            BatteryLevel = 100;
        }
        public string Brand
        {
            get => brand;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand= value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        // might have an issue to be private 
        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber= value;
            }

        }
        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void Drive(double mileage)
        {
            // fix battery percentage
            double percent =  mileage/ MaxMileage ;            
            
            if (this.GetType().Name == "CargoVan")
            {
                percent += 0.05;
            }

            percent *= 100;

            MaxMileage -= mileage;

            BatteryLevel = (int)Math.Round(100-percent); 

        }
        
        public void ChangeStatus()
        {
            IsDamaged = !IsDamaged;
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            //"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK / damaged"
            StringBuilder sb = new();

            sb.AppendLine($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: ");

            string statusDamagedOrNot = this.IsDamaged ? "damaged" : "OK";

            sb.Append(statusDamagedOrNot);

            return sb.ToString().TrimEnd(); ;
        }
    }
}
