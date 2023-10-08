using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int baterry)
        {
            Model = model;
            Color = color;
            Batery = baterry;
        }
           

        public string Model { get; set; }
        public string Color { get; set; }
        public int Batery { get; set; }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Batery} Batteries{Environment.NewLine}" +
                $"{Start() + Environment.NewLine}" +
                $"{Stop()}";
        }
    }
}
