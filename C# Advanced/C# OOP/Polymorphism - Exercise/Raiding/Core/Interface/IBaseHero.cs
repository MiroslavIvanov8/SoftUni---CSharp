using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core.Interface
{
    public interface IBaseHero
    {
        public int Power { get; }
        public string Name { get; }
        string CastAbility();
    }
}
