﻿using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }

        public string Name 
        { get => name; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            } 
        }

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2} lv";

        }
    }
}
