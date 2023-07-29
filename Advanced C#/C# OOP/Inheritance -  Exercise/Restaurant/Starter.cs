using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Starter : Food
    {
        public Starter(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
}
