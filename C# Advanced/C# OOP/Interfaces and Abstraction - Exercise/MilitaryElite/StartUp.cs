using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}