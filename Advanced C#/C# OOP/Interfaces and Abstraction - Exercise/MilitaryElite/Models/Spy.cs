using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Spy : Solider, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get;private  set; }
        public override string ToString()
        {
            string result = base.ToString();
            return result + Environment.NewLine +
                $"Code Number: {CodeNumber}";
        }
    }
}
