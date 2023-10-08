using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model) => heroes.Add(model);

        public IHero FindByName(string name) => heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model) => heroes.Remove(heroes.FirstOrDefault(x => x.Name == model.Name));
    }
}
