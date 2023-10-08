using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IBuyer, IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string Id, string birthDate)
        {
            Name = name;
            Age = age;
            Birthdate = birthDate;
            this.Id = Id;
            Food = food;
        }
        private const int food = 0;
        public int Food { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
