using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Beverage : Product
    {
        public double Mililitres { get; set; }
        public Beverage(string name, decimal price, double mililitres) : base (name, price)
        {
            Mililitres = mililitres;
        }
                
    }
} 
