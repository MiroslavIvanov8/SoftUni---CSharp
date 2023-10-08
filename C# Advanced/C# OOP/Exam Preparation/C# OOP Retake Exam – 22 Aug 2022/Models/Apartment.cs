using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class Apartment : Room
    {
        private const int ApartmentBedCapacity = 6;
        public Apartment() : base(ApartmentBedCapacity)
        {
        }
    }
}
