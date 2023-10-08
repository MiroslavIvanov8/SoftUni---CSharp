using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double wildth, double heigth)
        {
            Length = length;
            Width = wildth;
            Height = heigth;
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Height cannot be zero or negative.");
                height = value;
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Width cannot be zero or negative.");
                width = value;
            }
        }


        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Length cannot be zero or negative.");
                length = value;
            }
        }
        public override string ToString() =>
            $"Surface Area - {SurfaceArea():f2}" +
            $"{Environment.NewLine} Lateral Surface Area - {LateralSurfaceArea():f2}" +
            $"{Environment.NewLine}Volume - {Volume():f2}";

        public double SurfaceArea() => 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        public double LateralSurfaceArea() => 2 * length * height + 2 * width * height;
        public double Volume() => length * width * height;

    }
}
