using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Elf : Hero
    {
        public Elf(string username, int level) : base(username,level)
        {
            
        }
    }
    public class MuseElf : Elf
    {
        public MuseElf(string username, int level) : base(username,level)
        {

        }
    }
}
