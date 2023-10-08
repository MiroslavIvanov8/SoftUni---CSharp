using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal Create(string[] info);
    }
}
