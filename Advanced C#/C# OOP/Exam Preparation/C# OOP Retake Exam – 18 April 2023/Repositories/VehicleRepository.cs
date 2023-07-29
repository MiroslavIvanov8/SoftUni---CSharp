using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> vehicles;
        public VehicleRepository()
        {
            vehicles= new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }
        public bool RemoveById(string identifier) => vehicles.Remove(this.FindById(identifier));

        public IVehicle FindById(string identifier) => vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll() => this.vehicles;
        

    }
}

