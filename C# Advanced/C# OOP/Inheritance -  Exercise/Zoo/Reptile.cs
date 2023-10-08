using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Reptile : Animal
    {
        public Reptile(string name) : base( name)
        {

        }
    }
    public class Lizard : Reptile
    {
        public Lizard(string name) : base(name)
        {

        }
    }
    public class Snake : Reptile
    {
        public Snake(string name) : base(name)
        {

        }
    }
}
