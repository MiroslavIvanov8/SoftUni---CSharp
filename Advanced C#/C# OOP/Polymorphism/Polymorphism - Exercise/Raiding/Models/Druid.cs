using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int Power = 80;
        public Druid(string name) 
            : base(name, Power) {}

        public override string CastAbility()
        {
            return $"{Name} healed for {Power}";
        }
        
    }
}
