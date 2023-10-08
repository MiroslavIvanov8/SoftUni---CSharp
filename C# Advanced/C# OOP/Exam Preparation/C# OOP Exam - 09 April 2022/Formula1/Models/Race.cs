using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private readonly IRepository<IPilot> pilots;        
       
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps= numberOfLaps;
            TookPlace = false;
            pilots = new PilotRepository();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value.ToString()));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => (ICollection<IPilot>)pilots.Models;

        public void AddPilot(IPilot pilot) => pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {pilots.Models.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}");

            string tookPlace = TookPlace ? "Yes" : "No";

            sb.AppendLine($"Took place: {tookPlace}");
            return sb.ToString().TrimEnd();

        }
    }
}
