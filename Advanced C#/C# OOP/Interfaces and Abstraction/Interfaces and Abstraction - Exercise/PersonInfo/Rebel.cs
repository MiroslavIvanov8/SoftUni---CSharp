using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Rebel : IBuyer,IPerson
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = food;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public string Birthdate => throw new NotImplementedException();

        private const int food = 0;
        public int BuyFood()
        {
            Food += 5;
            return 5;
        }
    }
}
