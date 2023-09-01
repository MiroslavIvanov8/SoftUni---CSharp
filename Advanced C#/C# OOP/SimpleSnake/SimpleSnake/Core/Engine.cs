using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Point[] pointOfDirections;
        private Direction direction;

        private Snake snake;
        private Wall wall;
        private float sleepTime;
        public Engine(Wall wall,Snake snake)
        {
            this.pointOfDirections = new Point[4];

            this.pointOfDirections[0] = new Point(1, 0);
            this.pointOfDirections[1] = new Point(-1, 0);
            this.pointOfDirections[2] = new Point(0, 1);
            this.pointOfDirections[3] = new Point(0, -1);

            this.sleepTime = 100;

            this.wall = wall;
            this.snake = snake;
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(this.pointOfDirections[(int)direction]);

                if (!isMoving)
                {
                    AskUserToRestart();
                }

                sleepTime -= 0.01f;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserToRestart()
        {
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Would you like to restart ? ");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(3, 3);
                Console.WriteLine("Game Over");
                Environment.Exit(0);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                     this.direction = Direction.Left;
                }
            } 
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;


        }
    }
}
