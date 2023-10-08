using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
		private string name;
		private int age;
		private string gender;

		public Animal(string name, int age,string gender)
		{
			Name= name;
			Age= age;
			Gender= gender;

		}
		public string Gender
		{
			get { return gender; }
			set { gender = value; }
		}


		public int Age
		{
			get { return age; }
			set { age = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public virtual string ProduceSound() => null;
		public override string ToString() => $"{GetType().ToString().Split('.').Last()}" + Environment.NewLine +
			$"{Name} {Age} {Gender}" + Environment.NewLine +
			$"{ProduceSound()}";
    }
}
