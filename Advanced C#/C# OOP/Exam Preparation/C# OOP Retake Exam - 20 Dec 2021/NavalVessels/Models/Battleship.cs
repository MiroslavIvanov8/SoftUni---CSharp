using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const  double WeaponCaliberIncrease = 40;

        private const double InitialArmounrThichness = 300;

        private const double SpeedIncrease = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed) :
            base(name,mainWeaponCaliber,speed, InitialArmounrThichness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }
       
        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                this.MainWeaponCaliber += WeaponCaliberIncrease;
                this.Speed -= SpeedIncrease;
            }
            else
            {
                this.MainWeaponCaliber -= WeaponCaliberIncrease;
                this.Speed += SpeedIncrease;
            }

            SonarMode = !SonarMode;
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmounrThichness;
        }
        public override string ToString()
        {
            string sonarModeOnOff = this.SonarMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarModeOnOff}";

        }
    }
}
