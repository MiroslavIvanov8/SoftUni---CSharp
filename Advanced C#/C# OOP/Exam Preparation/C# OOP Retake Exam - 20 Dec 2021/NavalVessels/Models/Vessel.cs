using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        
        private ICaptain captain;
        public Vessel()
        {
            Targets = new List<string>();
        }
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : 
            this()

        {   
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;            
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name),ExceptionMessages.InvalidVesselName);
                }

                name = value;                
            }
        }

        public ICaptain Captain 
        {
            get 
            {
                return captain;
            }
             set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; set; }

        public double Speed { get; set; }

        public ICollection<string> Targets { get; set; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            this.Targets.Add(target.Name);

            this.Captain.IncreaseCombatExperience();

            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {this.ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($" *Speed: {this.Speed} knots");

            string targetsToAppend = " *Targets:";

            if (this.Targets.Any())
            {
                
                targetsToAppend +=" " + string.Join(", ", this.Targets);
            }

            else
            {
                targetsToAppend += " None";
            }
            sb.AppendLine(targetsToAppend);

            return sb.ToString().TrimEnd(); 
                                
        }

    }
}
