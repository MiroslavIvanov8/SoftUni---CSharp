using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dessert : Food
    {
        public double Calories { get; set; }
        public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
            Calories = calories;
        }
    }
    public class Cake : Dessert
    {
        private const decimal cakePrice = 5m;
        private const double cakeGrams = 250;        
        private const double cakeCalories = 1000;

        public Cake(string name, decimal price, double grams, double calories) : base(name, cakePrice, cakeGrams, cakeCalories)
        {

        }
    }
}





