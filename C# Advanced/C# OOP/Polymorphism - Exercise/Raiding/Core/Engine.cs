using Raiding.Core.Interface;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    
    public class Engine : IEngine
    {
        private IFactory heroFactory;
        public Engine(IFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfHeroes = 0;
            ICollection<IBaseHero> heroes = new List<IBaseHero>();

            while(numberOfHeroes<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    IBaseHero hero = heroFactory.Create(type, name);

                    heroes.Add(hero);
                    numberOfHeroes++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.GetType().Name} - {hero.CastAbility()}") ;
                heroesPower += hero.Power;
            }

            if(heroesPower>=bossPower)
                Console.WriteLine("Victory!");

            else
                Console.WriteLine("Defeat...");
        }
    }
}
