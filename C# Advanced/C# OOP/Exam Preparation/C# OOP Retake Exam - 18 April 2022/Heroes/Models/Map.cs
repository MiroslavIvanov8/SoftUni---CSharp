using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {
        
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();

            int aliveKnights = 0;
            int aliveBarbarians = 0;

            foreach (var hero in players.Where(h => h.Weapon != null && h.Health>0))
            {
                if (hero.IsAlive && hero.GetType().Name == nameof(Knight))
                {
                    knights.Add(hero);
                }
                else if (hero.IsAlive && hero.GetType().Name == nameof(Barbarian))
                {
                    barbarians.Add(hero);
                }
            }

            while (true)
            {
                if (!knights.Any(k => k.IsAlive))
                {
                    break;
                }
                if (!barbarians.Any(b => b.IsAlive))
                {
                    break;
                }
                
                foreach (Knight knight in knights.Where(k=>k.IsAlive))
                {
                    foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }  
                }
                foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (Knight knightTarget in knights.Where(k=>k.IsAlive))
                    {
                        knightTarget.TakeDamage(barbarian.Weapon.DoDamage());                        
                    }
                }

            }

            if (knights.Any(k=>k.IsAlive))
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        aliveKnights++;
                    }
                }
                return string.Format(OutputMessages.MapFightKnightsWin,knights.Count()-aliveKnights);
            }
            else
            {
                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        aliveBarbarians++;
                    }
                }
                return string.Format(OutputMessages.MapFigthBarbariansWin, barbarians.Count() - aliveBarbarians);
            }

        }
    }
}
