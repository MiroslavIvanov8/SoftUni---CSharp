using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY) :
            base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
            => snakeHead.leftX == 0
            || snakeHead.topY == 0
            || snakeHead.leftX == this.leftX
            || snakeHead.topY == this.topY;
            
        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.topY-1);

            SetVerticalLine(0);
            SetVerticalLine(this.leftX-1);
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.leftX; leftX++)
            {
                Draw(leftX,topY, wallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.topY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
