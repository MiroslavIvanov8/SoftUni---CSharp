using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
		private string name;

		public List<Topping> toppings;
		public Pizza(string name)
		{
			Name = name;
			toppings= new List<Topping>();
		}
		public string Name
		{
			get { return name; }
			set 
			{
				if (value.Length >= 1 && value.Length <= 15 && value!=string.Empty)
					name = value;
				else
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
			}
		}
		public void AddToping(Topping topping)
		{
			if (toppings.Count <= 10)
			{
				toppings.Add(topping);
			}
			else
				throw new ArgumentException("Number of toppings should be in range [0..10].");	
		}
	}
}
