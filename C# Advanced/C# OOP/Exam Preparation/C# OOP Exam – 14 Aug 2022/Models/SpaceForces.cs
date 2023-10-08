﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models
{
    public class SpaceForces : MilitaryUnit
    {
        private const double SpaceForcesPrice = 11;
        public SpaceForces() :
            base(SpaceForcesPrice)
        {
        }
    }
}
