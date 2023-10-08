using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Stationaryphone : IStationary
    {
        public void Dialing(string number)
        {
            foreach (char ch in number)
            {
                if (char.IsLetter(ch))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
