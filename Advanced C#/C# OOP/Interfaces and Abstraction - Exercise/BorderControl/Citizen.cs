using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string Id)
        {
            Name = name;
            Age = age;            
            this.Id = Id;
        }

        
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
