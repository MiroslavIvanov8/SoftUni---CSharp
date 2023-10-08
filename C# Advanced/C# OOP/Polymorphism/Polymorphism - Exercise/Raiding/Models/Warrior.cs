using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int Power = 100;
        public Warrior(string name) 
            : base(name, Power){}

        public override string CastAbility()
        {
            return $"{Name} hit for {Power} damage";
        }

        
    }
}
