using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Snake 
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snake;
        private readonly Food[] food;
        private readonly Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        public Snake(Wall wall)
        {
            snake = new Queue<Point>();
            food = new Food[3];
            this.wall = wall;

            this.foodIndex = GetRandomPosition;

            this.CreateSnake();
            this.GetFood();

            this.food[this.foodIndex].SetRandomPosition(this.snake);
        }
        public int GetRandomPosition => new Random().Next(0,this.food.Length);
        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snake.Last();

            GetNextDirection(direction,currentSnakeHead);

            bool isPartOfSnake = 
                this.snake.Any(x => x.leftX == this.nextLeftX && x.topY == this.nextTopY);

            if (isPartOfSnake)
            {
                return false;
            }

            var newSnakeHead = new Point(nextLeftX, nextTopY);
            bool isWall = this.wall.IsPointOfWall(newSnakeHead);

            if (isWall)
            {
                 return false;
            }

            this.snake.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);
            

            if (this.food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction,newSnakeHead);
            }

            Point tail = this.snake.Dequeue();
            tail.Draw(' ');

            return true;
            
        }

        private void Eat(Point direction, Point newSnakeHead)
        {
            var foodPoints = this.food[foodIndex].foodPoints;

            for (int i = 0; i < foodPoints; i++)
            {
                this.snake.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextDirection(direction,newSnakeHead);
            }
             
            foodIndex = GetRandomPosition;
            this.food[this.foodIndex].SetRandomPosition(this.snake);

            

        }

        private void GetNextDirection(Point direcion,Point snakeHead)
        {
            this.nextLeftX = snakeHead.leftX + direcion.leftX;
            this.nextTopY = snakeHead.topY + direcion.topY;

            
        }
        private void GetFood()
        {
            this.food[0] = new FoodAsterisk(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodHash(this.wall);
        }

        private void CreateSnake()
        {
            for (int leftX = 3; leftX <= 9; leftX++)
            {
                snake.Enqueue(new Point(leftX, 3));
            }
        }
    }
}
