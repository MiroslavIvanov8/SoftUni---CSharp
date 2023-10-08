using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models
{
    public class StormTroopers : MilitaryUnit
    {
        private const double StormTroopersPrice = 2.5;
        public StormTroopers() :
            base(StormTroopersPrice)
        {
        }
    }
}
