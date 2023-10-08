using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes = new HeroRepository();
        private readonly IRepository<IWeapon> weapons = new WeaponRepository();
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(h => h.Name == name))
            {
                return string.Format(OutputMessages.HeroAlreadyExist, name);
            }
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                return string.Format(OutputMessages.HeroTypeIsInvalid);
            }
            else if (type == nameof(Knight))
            {
                IHero hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            else 
            {
                IHero hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(w => w.Name == name))
            {
                return string.Format(OutputMessages.WeaponAlreadyExists, name);
            }
            if (type != nameof(Claymore) && type != nameof(Mace))
            {
                return string.Format(OutputMessages.WeaponTypeIsInvalid);
            }
            else if (type == nameof(Claymore))
            {
                IWeapon weapon = new Claymore(name, durability);
                weapons.Add(weapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }
            else
            {
                IWeapon weapon = new Mace(name, durability);
                weapons.Add(weapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }

        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(h => h.Name == heroName))
            {
                return string.Format(OutputMessages.HeroDoesNotExist,heroName);
            }
            if (!weapons.Models.Any(w => w.Name == weaponName))
            {
                return string.Format(OutputMessages.WeaponDoesNotExist, weaponName);
            }

            IHero hero = heroes.FindByName(heroName);
            if (hero.Weapon != null)
            {
                return string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName);
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
            
        }

        public string StartBattle()
        {
            IMap map = new Map();
            return map.Fight((ICollection<IHero>)heroes.Models);
        }


        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IHero hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                  .AppendLine($"--Health: {hero.Health}")
                  .AppendLine($"--Armour: {hero.Armour}");
                  string weaponYesOrNo = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";
                  sb.AppendLine($"--Weapon: {weaponYesOrNo}");               
            }

            return sb.ToString().TrimEnd();
        }

    }
}
