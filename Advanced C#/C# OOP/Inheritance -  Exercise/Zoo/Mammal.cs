using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Mammal : Animal
    {
        public Mammal(string name) : base(name)
        {

        }
    }
    public class Gorilla : Mammal
    {
        public Gorilla(string name) : base(name)
        {

        }
    }
    public class Bear : Mammal
    {
        public Bear(string name) : base(name)
        {

        }
    }
}
