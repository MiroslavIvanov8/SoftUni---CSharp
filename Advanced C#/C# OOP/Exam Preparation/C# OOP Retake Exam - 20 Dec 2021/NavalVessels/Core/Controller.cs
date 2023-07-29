using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Any(c=>c.FullName==fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, captain.FullName);
            }

            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, captain.FullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel existingVessel = vessels.FindByName(name);
            if (existingVessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel producedVessel;

            if (vesselType == "Battleship")
            {
                producedVessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                producedVessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            vessels.Add(producedVessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain selectedCaptain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            IVessel selectedVessel = vessels.FindByName(selectedVesselName);

            if (selectedCaptain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (selectedVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }           

            if (selectedVessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVessel.Captain.FullName);
            }
            
            selectedCaptain.AddVessel(selectedVessel);
            selectedVessel.Captain = selectedCaptain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        // be cautious captain may not exist
        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.First(c=>c.FullName == captainFullName);
            
            return captain.Report();
        }
        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel?.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            Battleship battleship = (Battleship)this.vessels.FindByName(vesselName);

            if (battleship != null)
            {
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            Submarine submarine = (Submarine)this.vessels.FindByName(vesselName);

            if (submarine != null)
            {
                submarine.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
            
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if(vessel != null)
            {
                vessel.RepairVessel();
                return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vessels.FindByName(attackingVesselName);
            IVessel defender = this.vessels.FindByName(defendingVesselName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if(defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }



    }
}
