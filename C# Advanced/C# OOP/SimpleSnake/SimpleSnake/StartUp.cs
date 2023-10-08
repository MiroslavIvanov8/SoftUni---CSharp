namespace SimpleSnake
{
    using SimpleSnake.Core;
    using System.Drawing;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(50,20);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall,snake);
            engine.Run();
            
        }
    }
}
