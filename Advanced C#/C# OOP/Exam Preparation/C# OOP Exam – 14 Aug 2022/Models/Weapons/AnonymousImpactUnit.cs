using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double AnonymousImpactUnitPrice = 30;
        public AnonymousImpactUnit() :
            base(AnonymousImpactUnitPrice)
        {
        }
    }
}
