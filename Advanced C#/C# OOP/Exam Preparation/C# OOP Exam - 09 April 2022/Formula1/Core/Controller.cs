using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPilot> pilots = new PilotRepository();
        private readonly IRepository<IRace> races = new RaceRepository();
        private readonly IRepository<IFormulaOneCar> cars = new FormulaOneCarRepository();
        public Controller()
        {

        }
        public string CreatePilot(string fullName)
        {
            if (pilots.Models.Any(p => p.FullName == fullName))
            {
                return string.Format(ExceptionMessages.PilotExistErrorMessage, fullName);
            }

            IPilot pilot = new Pilot(fullName);

            pilots.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot,fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (cars.Models.Any(c => c.Model == model))
            {
                return string.Format(ExceptionMessages.CarExistErrorMessage, model);
            }

            IFormulaOneCar car;
            if (type != nameof(Ferrari) && type != nameof(Williams))
            {
                return string.Format(ExceptionMessages.InvalidTypeCar, type);
            }
            else if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.Models.Any(r => r.RaceName == raceName))
            {
                return string.Format(ExceptionMessages.RaceExistErrorMessage, raceName);
            }

            IRace race = new Race(raceName, numberOfLaps);

            races.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilots.Models.Any(p => p.FullName == pilotName) )
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName);
            }

            IPilot pilot = pilots.FindByName(pilotName);

            if (pilot.Car != null)
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName);
            }

            if (!cars.Models.Any(c => c.Model == carModel))
            {
                return string.Format(ExceptionMessages.CarDoesNotExistErrorMessage,carModel);
            }
            
            IFormulaOneCar car = cars.FindByName(carModel);

            pilot.AddCar(car);
            cars.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar,pilotName,car.GetType().Name, carModel); 
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!races.Models.Any(r => r.RaceName == raceName))
            {
                return string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName);
            }
            if (!pilots.Models.Any(p => p.FullName == pilotFullName))
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName);
            }

            IPilot pilot = pilots.FindByName(pilotFullName);

            if (pilot.CanRace == false)
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName);
            }
            
            IRace race = races.FindByName(raceName);

            if (race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName);
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,raceName);
        }

        public string StartRace(string raceName)
        {
            if (!races.Models.Any(r => r.RaceName == raceName))
            {
                return string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName);
            }

            IRace race = races.FindByName(raceName);
            if (race.Pilots.Count < 3)
            {
                return string.Format(ExceptionMessages.InvalidRaceParticipants, raceName);
            }

            if (race.TookPlace == true)
            {
                return string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName);
            }

            // not sure this works as intended
            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                IPilot pilot = orderedPilots[i];

                if (i == 0)
                {
                    pilot.WinRace();
                    sb.AppendLine($"Pilot {pilot.FullName} wins the {raceName} race.");
                }
                if (i == 1)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is second in the {raceName} race.");
                }
                if (i == 2)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is third in the {raceName} race.");
                }
            }
            race.TookPlace = true;

            return sb.ToString().TrimEnd();
        }
        public string RaceReport()
        {
            StringBuilder sb  = new StringBuilder();

            foreach (var race in races.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb  = new StringBuilder();
            foreach (var pilot in pilots.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
