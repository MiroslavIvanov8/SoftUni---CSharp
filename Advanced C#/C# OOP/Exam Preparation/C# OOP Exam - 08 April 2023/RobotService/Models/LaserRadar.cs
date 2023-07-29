using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int InterfaceStandardLazerRadar = 20082;
        private const int BatteryUsageLazarRadar = 5000;
        public LaserRadar() :
            base(InterfaceStandardLazerRadar, BatteryUsageLazarRadar)
        {
        }
    }
}
