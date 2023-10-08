using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private const int CombatExperienceChange = 10;
        private string fullName;
        //private ICollection<IVessel> vessels;
        public Captain()
        {
            this.Vessels = new HashSet<IVessel>();
            CombatExperience = 0;
        }
        public Captain(string fullName) : 
            this()
        {
            FullName = fullName;
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.FullName),ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselName);
            }
            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += CombatExperienceChange;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");
            if (this.Vessels.Any())
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }            
            return sb.ToString().TrimEnd();
        }
    }
}
