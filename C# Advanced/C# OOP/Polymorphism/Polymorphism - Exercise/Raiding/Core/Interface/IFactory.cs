using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core.Interface
{
    public interface IFactory
    {
        public IBaseHero Create(string type, string name);
    }
}
