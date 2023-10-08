using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;
        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.vessels;
        public VesselRepository()
        {
            this.vessels= new HashSet<IVessel>();
        }

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name) => Models.FirstOrDefault(x => x.Name == name);
        

        public bool Remove(IVessel model) => vessels.Remove(model);
        
    }
}
