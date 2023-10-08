using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        {

        }
    }
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username,level)
        {

        }
    }
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username,int level) : base(username,level)
        {

        }
    }
}
