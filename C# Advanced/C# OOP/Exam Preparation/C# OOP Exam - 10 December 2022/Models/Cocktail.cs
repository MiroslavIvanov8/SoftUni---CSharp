using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;            
            
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size{ get; private set;}
        public double Price 
        { 
            get => price;
            private set 
            {
                double devider; // this is messed up 

                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    devider = 2d / 3d;
                    price = value * devider;
                }
                else
                {
                    devider= 1d / 3d;
                    price = devider * value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }

    }
}
