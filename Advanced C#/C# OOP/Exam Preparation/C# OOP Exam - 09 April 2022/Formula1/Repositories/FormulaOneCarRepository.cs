using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars= new List<IFormulaOneCar>();
        public IReadOnlyCollection<IFormulaOneCar> Models => cars;

        public void Add(IFormulaOneCar model) => cars.Add(model);

        public IFormulaOneCar FindByName(string name) => cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(IFormulaOneCar model) => cars.Remove(cars.FirstOrDefault(c=>c.Model == model.Model));
    }
}
