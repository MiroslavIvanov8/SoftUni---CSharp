﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal interface IElectricCar : ICar
    {
        public int Batery { get; set; }
    }
}
