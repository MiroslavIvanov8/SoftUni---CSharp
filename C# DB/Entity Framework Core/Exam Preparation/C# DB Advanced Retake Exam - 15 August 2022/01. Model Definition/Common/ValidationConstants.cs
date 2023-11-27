using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Common
{
    public static class ValidationConstants
    {
        //Truck
        public const int TruckRegistrationNumberLength = 8;
        public const int TruckVinNumberLength = 17;

        //Client
        public const int ClientNameLength = 40;
        public const int ClientNationalityLength = 40;

        //Despatcher
        public const int DespatcherNameLength = 40;
    }
}
