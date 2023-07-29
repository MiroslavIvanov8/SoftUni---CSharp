using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public class Gingerbread : Delicacy
    {
        private const double GingerBreadPrice = 4.00;
        public Gingerbread(string delicacyName ) : base(delicacyName, GingerBreadPrice)
        {
        }
    }
}
