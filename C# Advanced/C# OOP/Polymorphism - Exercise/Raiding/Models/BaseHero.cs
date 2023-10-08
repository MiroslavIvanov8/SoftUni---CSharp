using Raiding.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name, int power)
        {
            Name= name;
            Power= power;
        }
        public int Power { get; private set; }
        public string Name { get; private set; }
        public abstract string CastAbility();        

    }
}
