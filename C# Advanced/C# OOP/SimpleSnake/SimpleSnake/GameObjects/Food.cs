using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;

        protected Food(Wall wall, char foodSymbol, int points) :
            base(wall.leftX,wall.topY)
        {
            this.wall = wall;
            this.foodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }
        
        public int foodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.leftX = random.Next(2,wall.leftX-2);
            this.topY = random.Next(2, wall.topY - 2);

            bool isPointOfSnake = snake.Any(x=>x.leftX == this.leftX && x.topY == this.topY);

            while (isPointOfSnake)
            {
                this.leftX = random.Next(2, wall.leftX - 2);
                this.topY = random.Next(2, wall.topY - 2);

                isPointOfSnake = snake.Any(x => x.leftX == this.leftX && x.topY == this.topY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)=>
            snakeHead.leftX ==this.leftX && snakeHead.topY ==this.topY;
        
    }
}
