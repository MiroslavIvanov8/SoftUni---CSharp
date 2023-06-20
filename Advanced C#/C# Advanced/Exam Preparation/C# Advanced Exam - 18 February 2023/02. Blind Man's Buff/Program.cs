using System.Numerics;

namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = data[0];
            int cols = data[1];
            string[,] matrix = new string[rows, cols];
            int moves = 0;
            int playersCaught = 0;
            for (int row = 0; row < rows; row++)
            {
                string[] matrixInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixInfo[col];
                }
            }
            string direction = string.Empty;

            bool moveMade = false;
            while((direction = Console.ReadLine())!="Finish")
            {
                moveMade = false;
                if (playersCaught == 3)
                    break;
                
                for (int row = 0; row < rows; row++)
                {

                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == "B")
                        {
                            if (IsCellValid(matrix, row, col, rows, cols, direction))
                            {
                                if (!moveMade)
                                {
                                    moveMade = true;
                                    moves++;
                                    if (direction == "left")
                                    {
                                        if (matrix[row, col - 1] == "P")
                                        {
                                            matrix = PlayerTouch(matrix, row, col, rows, cols, direction);
                                            playersCaught++;
                                        }
                                        else
                                        {
                                            matrix = BlindMove(matrix, row, col, rows, cols, direction);
                                        }
                                    }
                                    if (direction == "right")
                                    {
                                        if (matrix[row, col + 1] == "P")
                                        {
                                            matrix = PlayerTouch(matrix, row, col, rows, cols, direction);
                                            playersCaught++;
                                        }
                                        else
                                        {
                                            matrix = BlindMove(matrix, row, col, rows, cols, direction);
                                        }
                                    }
                                    if (direction == "up")
                                    {
                                        if (matrix[row - 1, col] == "P")
                                        {
                                            matrix = PlayerTouch(matrix, row, col, rows, cols, direction);
                                            playersCaught++;
                                        }
                                        else
                                        {
                                            matrix = BlindMove(matrix, row, col, rows, cols, direction);
                                        }
                                    }
                                    if (direction == "down")
                                    {
                                        if (matrix[row + 1, col] == "P")
                                        {
                                            matrix = PlayerTouch(matrix, row, col, rows, cols, direction);
                                            playersCaught++;
                                        }
                                        else
                                        {
                                            matrix = BlindMove(matrix, row, col, rows, cols, direction);
                                        }
                                    }
                                    else
                                        break;
                                }
                                
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {playersCaught} Moves made: {moves}");

        }
        static string[,] BlindMove(string[,] matrix, int row, int col, int rows, int cols, string direction)
        {
            if (direction == "left")
            {
                matrix[row, col - 1] = "B";
                matrix[row, col] = "-";
            }
            else if (direction == "right")
            {
                matrix[row, col + 1] = "B";
                matrix[row, col] = "-";
            }
            else if (direction == "down")
            {
                matrix[row + 1, col] = "B";
                matrix[row, col] = "-";
            }
            else if (direction == "up")
            {
                matrix[row - 1, col] = "B";
                matrix[row, col] = "-";
            }

            return matrix;
        }
        static string[,] PlayerTouch(string[,] matrix, int row, int col, int rows, int cols, string direction)
        {            
            if (direction == "left")
            {
                matrix[row, col - 1] = "B";
                matrix[row, col] = "-";                
            }
            else if (direction == "right")
            {
                matrix[row, col + 1] = "B";
                matrix[row, col] = "-";
            }
            else if (direction == "down")
            {
                matrix[row + 1, col] = "B";
                matrix[row , col] = "-";
            }
            else if (direction == "up")
            {
                matrix[row - 1, col] = "B";
                matrix[row, col] = "-";
            }
            
            return matrix;
        }
        static bool IsCellValid(string[,] matrix, int row, int col, int rows, int cols, string direction)
        {
            if (direction == "left")
            {
                return col- 1 >= 0 && matrix[row , col - 1] != "O";

            }
            else if (direction == "right")
            {
                return col + 1 < cols && matrix[row, col+1] != "O";
            }
            else if (direction == "up")
            {
                return row - 1 >= 0 && matrix[row -1, col] != "O";
            }
            else if (direction == "down")
            {
                return row + 1 < rows && matrix[row + 1 , col] != "O";
            }
            return false;
        }
    }
    
}