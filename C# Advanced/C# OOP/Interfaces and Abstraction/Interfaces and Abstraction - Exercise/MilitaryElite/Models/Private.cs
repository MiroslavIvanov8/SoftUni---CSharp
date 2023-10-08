using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Solider, IPrivate
    {
        public decimal Salary { get; private set; }
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }
        public override string ToString()
        {
            string result = base.ToString() + $" Salary: {Salary:f2}";
            return result;
        }
    }
}
