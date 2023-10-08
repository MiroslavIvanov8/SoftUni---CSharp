namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix  = new char[size,size];
            int moveCounter = 0;
            int hazelnutCount = 0;
            
                
                for (int row = 0; row < size; row++)
                {
                    string info = Console.ReadLine();
                    for (int col = 0; col < size; col++)
                    {
                        matrix[row, col] = info[col];
                    }
                }
            while (true)
            {
                if (hazelnutCount == 3)
                {
                    Console.WriteLine($"Good job! You have collected all hazelnuts!");
                    Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
                    break;
                }
                if (moveCounter == moves.Length && hazelnutCount < 3) /// dunno what to do about last test 07....
                    return;
                for (int move = 0; move < moves.Length; move++)
                {                    
                    string currMove = moves[move];
                    bool moveMade = true;

                    for (int row = 0; row < size; row++)
                    {

                        for (int col = 0; col < size; col++)
                        {
                            if (currMove == "left" && moveMade == true)
                            {

                                if (matrix[row, col] == 's')
                                {
                                    ;
                                    if (IsValid(matrix, row, col - 1, size))
                                    {
                                        if (matrix[row, col - 1] == 'h')
                                        {
                                            PickingHazelnuts(matrix, row, col, currMove);
                                            hazelnutCount++;
                                            moveMade = false;                                            
                                            break;
                                        }
                                        else if (matrix[row, col - 1] == '*')
                                        {
                                            SquirrelMoving(matrix, row, col, currMove);
                                            moveMade = false;                                            
                                            break;
                                        }
                                        else if (matrix[row, col - 1] == 't')
                                        {
                                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                            EndGame(hazelnutCount);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The squirrel is out of the field.");
                                        EndGame(hazelnutCount);
                                        return;
                                    }
                                }
                            }
                            else if (currMove == "up" && moveMade == true)
                            {
                                if (matrix[row, col] == 's')
                                {
                                    if (IsValid(matrix, row - 1, col, size))
                                    {
                                        if (matrix[row - 1, col] == 'h')
                                        {
                                            PickingHazelnuts(matrix, row, col, currMove);
                                            hazelnutCount++;
                                            moveMade = false;
                                            break;
                                        }
                                        else if (matrix[row - 1, col] == '*')
                                        {
                                            ;
                                            SquirrelMoving(matrix, row, col, currMove);
                                            moveMade = false;
                                            break;

                                        }
                                        else if (matrix[row - 1, col] == 't')
                                        {
                                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                            EndGame(hazelnutCount);
                                            return;
                                        }
                                    }
                                    else if (!IsValid(matrix, row - 1, col, size))
                                    {
                                        Console.WriteLine("The squirrel is out of the field.");
                                        EndGame(hazelnutCount);
                                        return;
                                    }
                                }

                            }
                            else if (currMove == "right" && moveMade == true)
                            {
                                if (matrix[row, col] == 's')
                                {
                                    if (IsValid(matrix, row, col + 1, size))
                                    {
                                        if (matrix[row, col + 1] == 'h')
                                        {
                                            PickingHazelnuts(matrix, row, col, currMove);
                                            hazelnutCount++;
                                            moveMade = false;
                                            break;
                                        }
                                        else if (matrix[row, col + 1] == '*')
                                        {
                                            ;
                                            SquirrelMoving(matrix, row, col, currMove);
                                            moveMade = false;
                                            break;
                                        }
                                        else if (matrix[row, col + 1] == 't')
                                        {
                                            ;
                                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                            EndGame(hazelnutCount);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The squirrel is out of the field.");
                                        EndGame(hazelnutCount);
                                        return;
                                    }
                                }
                            }
                            else if (currMove == "down" && moveMade == true)
                            {
                                if (matrix[row, col] == 's')
                                {
                                    if (IsValid(matrix, row + 1, col, size))
                                    {
                                        if (matrix[row + 1, col] == 'h')
                                        {
                                            PickingHazelnuts(matrix, row, col, currMove);
                                            hazelnutCount++;
                                            moveMade = false;
                                            break;
                                        }
                                        else if (matrix[row + 1, col] == '*')
                                        {
                                            ;
                                            SquirrelMoving(matrix, row, col, currMove);
                                            moveMade = false;
                                            break;
                                        }
                                        else if (matrix[row + 1, col] == 't')
                                        {
                                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                            EndGame(hazelnutCount);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The squirrel is out of the field.");
                                        EndGame(hazelnutCount);
                                        return;
                                    }
                                }
                            }
                            
                        }
                    }
                    moveCounter++;
                }
            }
            
        }
        static char[,] SquirrelMoving(char[,] matrix, int row, int col,string move)
        {
            if (move == "left")
            {
                matrix[row, col - 1] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "right")
            {
                matrix[row, col + 1] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "up")
            {
                matrix[row - 1, col] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "down")
            {
                matrix[row + 1, col] = 's';
                matrix[row, col] = '*';
            }
               return matrix;
         }
        static char[,] PickingHazelnuts(char[,] matrix, int row, int col,string move)
        {

            if (move == "left")
            {
                matrix[row, col - 1] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "right")
            {
                matrix[row, col + 1] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "up")
            {
                matrix[row - 1, col] = 's';
                matrix[row, col] = '*';
            }
            else if (move == "down")
            {
                matrix[row + 1, col] = 's';
                matrix[row, col] = '*';
            }
            return matrix;

        }
        static void EndGame(int hazelnutCount)
        {
            Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
        }
        static bool IsValid(char[,] matrix, int row, int col, int size)
        {
            return row>=0 
                && row < size
                && col>=0 
                && col < size;
        } 
    }
}