using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
    public class Fish : MainDish
    {
        private const double fishGrams = 22;
        public Fish(string name, decimal price, double grams) : base(name, price, fishGrams)
        {

        }
    }
}

