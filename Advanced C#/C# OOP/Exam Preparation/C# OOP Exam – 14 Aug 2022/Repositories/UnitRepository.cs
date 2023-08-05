using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> units= new List<IMilitaryUnit>();
        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model) => units.Add(model);

        public IMilitaryUnit FindByName(string unitTypeName) => units.FirstOrDefault(m => m.GetType().Name == unitTypeName);

        public bool RemoveItem(string unitTypeName) => units.Remove(units.FirstOrDefault(m => m.GetType().Name == unitTypeName));
    }
}
