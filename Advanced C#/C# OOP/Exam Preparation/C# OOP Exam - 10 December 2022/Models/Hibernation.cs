using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public class Hibernation : Cocktail
    {
        private const double HibernationPrice = 10.50;
        public Hibernation(string cocktailName, string size) :
            base(cocktailName, size, HibernationPrice)
        {
        }
    }
}
