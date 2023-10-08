using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly List<IRoute> routes;
        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }
        public bool RemoveById(string identifier)
        {
            IRoute route = routes.FirstOrDefault(v => v.RouteId == int.Parse(identifier));
            if (route == null)
            {
                return false;
            }
            else
            {
                return routes.Remove(route);
            }
        }

        public IRoute FindById(string identifier)=> routes.FirstOrDefault(v => v.RouteId == int.Parse(identifier));


        public IReadOnlyCollection<IRoute> GetAll() => this.routes;

    }
}
