using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<IRobot> robots;
        private IRepository<ISupplement> supplements;

        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;

            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                supplement = new SpecializedArm();
            }

            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);

        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            List<IRobot> robotsToSupport = new();

            foreach (var robot in robots.Models())
            {
                if (!robot.InterfaceStandards.Contains(supplement.InterfaceStandard))
                {
                    robotsToSupport.Add(robot);
                }
            }

            robotsToSupport = robotsToSupport.Where(r => r.Model == model).ToList(); 

            if (!robotsToSupport.Any())
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                IRobot robot = robotsToSupport.FirstOrDefault();

                robot.InstallSupplement(supplement);
                supplements.RemoveByName(supplementTypeName);
                return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
            }

        }
        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded) // need to fix robots's battery so it goest to 0 its totalpower needded > battery
        {
            List<IRobot> robotsToPerform = new();
            foreach (var robot in robots.Models().Where(r=>r.InterfaceStandards.Contains(intefaceStandard)))
            {
                robotsToPerform.Add(robot);
            }
            if (!robotsToPerform.Any())
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);

            int availablePower = 0;

            foreach (var robot in robotsToPerform)
            {
                availablePower += robot.BatteryLevel;
            }

            robotsToPerform = robotsToPerform.OrderByDescending(r => r.BatteryLevel).ToList();

            if (availablePower < totalPowerNeeded)
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);

            int cnt = 0;

            foreach (var robot in robotsToPerform)
            {
                cnt++;

                if (robot.BatteryLevel >= availablePower)
                {
                    robot.ExecuteService(totalPowerNeeded);

                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(totalPowerNeeded);
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, cnt);
        }
        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToReceover = robots.Models().Where(r=>r.BatteryLevel<r.BatteryCapacity/2).ToList();
            int cnt = 0;
            foreach (var robot in robotsToReceover)
            {
                robot.Eating(minutes);
                cnt++;  
            }

            return string.Format(OutputMessages.RobotsFed, cnt);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var robot in robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
