using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double mililitres) : base(name, price, mililitres)
        {

        }
    }
    public class Coffee : HotBeverage
    {
        private const double CoffeMililitres = 50;
        private const decimal CoffePrice = 3.50m;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine) : base(name, CoffePrice, CoffeMililitres)
        {

            Caffeine = caffeine;
        }


    }
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double mililitres) : base(name, price, mililitres)
        {

        }
    }


}
