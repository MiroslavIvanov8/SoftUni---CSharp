using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Browsing(string url)
        {
            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Calling(string number)
        {
            foreach (char ch in number)
            {
                if (char.IsLetter(ch))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
