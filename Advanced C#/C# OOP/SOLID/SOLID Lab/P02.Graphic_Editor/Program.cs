using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape triangle = new Triangle();
            List<IShape> shapes = new List<IShape>();
            shapes.Add(circle);
            shapes.Add(rectangle);
            shapes.Add(triangle);
            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
    }
}
