using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
	public class Tire
	{
		private int age;
		private double pressure;
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public Tire(int age,double pressure)
		{
			Age = age;
			Pressure = pressure;
		}
		public double Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}


	}
}
