using PlanetWars.Core.Contracts;
using PlanetWars.Models;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets = new PlanetRepository();
        public string CreatePlanet(string name, double budget)
        {

            if (planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);

            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                return string.Format(ExceptionMessages.UnexistingPlanet,planetName);
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Any(m => m.GetType().Name == unitTypeName))
            {
                return string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName);
            }

            IMilitaryUnit unit;
            if (unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(AnonymousImpactUnit))
            {
                return string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName);
            }

            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);// check what will happen if planet.Budget<price
            planet.AddUnit(unit); 
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                return string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName);
            }

            IWeapon weapon;
            if (weaponTypeName != nameof(SpaceMissiles) && weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon))
            {
                return string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                weapon = new NuclearWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);// check what will happen if planet.Budget<price

            planet.AddWeapon(weapon); 
            
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Count == 0)
            {
                return string.Format(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
            
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = planets.FindByName(planetOne);
            IPlanet defender = planets.FindByName(planetTwo);

            if(attacker.MilitaryPower == defender.MilitaryPower)
            {
                if   (attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) 
                  && !defender.Weapons.Any(w=>w.GetType().Name == nameof(NuclearWeapon)))
                {
                    // attacker winner
                    return ResourseDisposal(attacker,defender);

                }
                else if  (defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) 
                      && !attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    // defender winnder   
                    return ResourseDisposal(defender, attacker);
                }

                if  ((attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) && defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                    || 
                    (!attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) && !defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    // no winner
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }
            }

            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                // attacker winner
                return ResourseDisposal(attacker, defender);
            }
            
                   // defender winner
            return ResourseDisposal(defender, attacker);
            
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string ResourseDisposal(IPlanet winner, IPlanet loser)
        {
            winner.Spend(winner.Budget / 2);            
            winner.Profit(loser.Budget / 2);
            loser.Spend(loser.Budget / 2);

            double sum = 0;
            foreach (var unit in loser.Army)
            {
                sum += unit.Cost;
            }
            foreach (var weapon in loser.Weapons)
            {
                sum += weapon.Price;
            }
            winner.Profit(sum);
            planets.RemoveItem(loser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }
    }
}
