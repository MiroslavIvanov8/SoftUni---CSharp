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

namespace PlanetWars.Models
{
    public class Planet : IPlanet
    {
        private readonly IRepository<IWeapon> weapons = new WeaponRepository();
        private readonly IRepository<IMilitaryUnit> militaryUnits = new UnitRepository();
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            Name  = name;
            Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower 
        {
            get
            {
                double totalAmount = 0;
                double enduranceSum = 0;
                double weaponSum = 0;
                foreach (var unit in militaryUnits.Models)
                {
                    enduranceSum += unit.EnduranceLevel;
                }
                foreach (var weapon in weapons.Models)
                {
                    weaponSum += weapon.DestructionLevel;
                }
                totalAmount = enduranceSum + weaponSum;

                if (militaryUnits.Models.Any(m => m.GetType().Name == nameof(AnonymousImpactUnit)))
                {
                    totalAmount += totalAmount * 0.30;
                }
                if (weapons.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    totalAmount += totalAmount * 0.45;
                }

                return Math.Round(totalAmount, 3);
            }
            private set
            { 

            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => militaryUnits.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            if (militaryUnits.Models.Any(m => m.GetType().Name == nameof(unit)))
            {
                return;
            }
            militaryUnits.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapons.Models.Any(w => w.GetType().Name == nameof(weapon)))
            {
                return;
            }
            weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in militaryUnits.Models)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            budget -= amount;
        }
        public void Profit(double amount)
        {
            budget += amount;
        }
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID");

            sb.Append($"--Forces: ");
            if (!militaryUnits.Models.Any())
            {
                sb.AppendLine("No units");
            }

            else
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }
            sb.Append($"--Combat equipment: ");

            if (!weapons.Models.Any())
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var item in this.Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));
            }


            return sb.ToString().TrimEnd();
        }



    }
}
