using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            this.leftX = leftX;
            this.topY = topY;
        }
        public int leftX { get; set; }
        public int topY { get; set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
