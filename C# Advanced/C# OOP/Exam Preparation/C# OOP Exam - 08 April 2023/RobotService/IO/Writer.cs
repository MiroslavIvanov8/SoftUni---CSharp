namespace RobotService.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RobotService.IO.Contracts;
    using System;
    public class Writer : IWriter
    {
        public void Write(string message) => Console.Write(message);

        
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
