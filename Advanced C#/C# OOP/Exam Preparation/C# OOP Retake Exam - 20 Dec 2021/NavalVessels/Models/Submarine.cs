using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmourThickness = 200;
        private const double WeaponCaliberChange = 40;
        private const double SpeedChange = 4;
        public Submarine(string name, double mainWeaponCaliber, double speed) :
            base(name, mainWeaponCaliber, speed, InitialArmourThickness)
        {
            this.SubmergeMode = false;
        }
        public bool SubmergeMode {get;  private set; }
        

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmourThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.MainWeaponCaliber += WeaponCaliberChange;
                this.Speed -= SpeedChange;
            }
            else
            {
                this.MainWeaponCaliber -= WeaponCaliberChange;
                this.Speed += SpeedChange;
            }
            this.SubmergeMode = !this.SubmergeMode;
        }   
        public override string ToString()
        {
            string submergeModeOnOff = this.SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {submergeModeOnOff}";
        }
    }
}
