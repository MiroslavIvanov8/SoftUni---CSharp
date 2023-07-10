using Raiding.Core;
using Raiding.Core.Interface;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new Factory();
            Engine engine = new Engine(factory);
            engine.Run();
        }
    }
}