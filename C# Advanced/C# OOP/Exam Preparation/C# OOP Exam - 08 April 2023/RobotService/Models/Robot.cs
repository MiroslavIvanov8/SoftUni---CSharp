using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private List<int> interfaceStandarts;
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model= model;
            BatteryCapacity= batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            BatteryLevel = batteryCapacity;
            interfaceStandarts = new List<int>(); // not sure if should be a list 
        }
        public string Model
        {
            get => model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }
                batteryCapacity = value;
            }
        } // check install inteface method
        
        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandarts;

        public void Eating(int minutes)
        {
            int producedEnergy = minutes * ConvertionCapacityIndex;

            if (BatteryLevel + producedEnergy >= batteryCapacity)
            {
                BatteryLevel = batteryCapacity;
                return;

            }
            BatteryLevel += producedEnergy;
            return;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandarts.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;            
            BatteryLevel -= supplement.BatteryUsage;
        }
        public bool ExecuteService(int consumedEnergy) // need to fix somehow to drain battery to 0
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name} {Model}:")
                .AppendLine($"--Maximum battery capacity: {BatteryCapacity}")
                .AppendLine($"--Current battery level: {BatteryLevel}");

            string supplements = this.InterfaceStandards.Any() ? string.Join(" ", interfaceStandarts) : "none";
            sb.AppendLine(supplements);

            return sb.ToString().TrimEnd();
            
        }
    }
}
