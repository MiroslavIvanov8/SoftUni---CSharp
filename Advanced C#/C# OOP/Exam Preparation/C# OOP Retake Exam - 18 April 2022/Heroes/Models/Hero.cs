using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        public Hero(string name, int health, int armour)
        {
            Name= name;
            Health= health;
            Armour= armour;
            IsAlive= true;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0) // how we initialize a hero with 0 hp ???
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }
                armour = value;
            }
        }

        public IWeapon Weapon 
        { 
            get => weapon;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
                weapon = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (Health > 0)
                    return true;
                else
                    return false;
            }
            private set
            {

            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (Armour > 0)
            {
                if (Armour - points > 0)
                {
                    armour -= points;
                    return;
                }
                
                points -= Armour;
                Armour = 0;
            }

            if (Health - points > 0)
            {
                Health -= points;                
                return;
            }
            else
            {
                Health = 0;
                this.IsAlive= false;
            }

        }
    }
}
