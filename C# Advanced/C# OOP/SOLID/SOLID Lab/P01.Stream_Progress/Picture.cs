using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public class Picture : File
    {
        public Picture(string name,string aurthor, int length, int bytesSent) : base(name, length, bytesSent)
        {
            Author = aurthor;
        }

        public string Author { get; set; }
    }
}
