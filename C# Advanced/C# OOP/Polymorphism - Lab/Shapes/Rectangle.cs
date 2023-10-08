using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double width, double height)
        {
            Width= width;
            Height= height;
        }
        public double Width 
        { 
            get=>width;
            private set => width= value;
        }
        public double Height 
        {
            get => height;
            private set => height = value;
        }
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter() => 2 * Height + 2 * Width;

        
    }
}
