using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
		private double grams;
		private string toppingName { get; set; }
		private double modifier = 1.0;
		public Topping(string topping,double grams)
		{
            ToppingName = topping;
            Grams = grams;
            
		}
		public string ToppingName
        {
			get { return toppingName; }
			set
			{
				Dictionary<string, double> toppingNames = new();
                toppingNames.Add("meat", 1.2);
                toppingNames.Add("veggies", 0.8);
                toppingNames.Add("cheese", 1.1);
                toppingNames.Add("sauce", 0.9);
				toppingName = value.ToLower();
                if (!toppingNames.ContainsKey(toppingName))
				{
					char oldChar = value.First();
					char newChar = value.ToUpper().First();
					string toping = value.Replace(oldChar, newChar);
                    throw new ArgumentException($"Cannot place {toping} on top of your pizza.");
				}
				this.modifier = toppingNames[toppingName];
            }
		}



		public double Grams
		{
			get { return grams; }
			set 
			{ 
				if (value < 1 || value > 50)
					throw new ArgumentException($"{toppingName} weight should be in the range [1..50].");
				grams = value * 2;
			}
		}

		public double CalcCalories()
		{
			return this.grams * this.modifier;
		}
		
	}
}
