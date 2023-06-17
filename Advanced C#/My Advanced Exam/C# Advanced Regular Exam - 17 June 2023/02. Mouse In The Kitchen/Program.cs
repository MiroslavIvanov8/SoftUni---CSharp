namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(",",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowSize = sizes[0];
            int colSize = sizes[1];
            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCount = 0;
            bool isTrapped = false;
            char[,] matrix = new char[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                string rowInfo = Console.ReadLine();
                for(int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = rowInfo[col];
                    if (matrix[row, col] == 'M')
                    {
                        mouseRow= row;
                        mouseCol= col;
                    }
                    if (matrix[row, col] == 'C')
                        cheeseCount++;
                }
            }

            string direction = string.Empty;
            while (true)             
            {
                direction = Console.ReadLine();
                if (direction == "danger")
                {
                    Console.WriteLine("Mouse will come back later!");
                    break;
                }
                if (cheeseCount == 0)
                    break;
                int newRow = mouseRow;
                int newCol = mouseCol;

                if (direction == "left")
                {
                    newCol--;
                    if (IsMoveValid(newRow, newCol, rowSize, colSize))
                    {
                        Movement(newRow,newCol,matrix,ref cheeseCount,ref isTrapped,ref mouseRow,ref mouseCol);
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
                else if (direction == "right")
                {
                    newCol++;
                    if (IsMoveValid(newRow, newCol, rowSize, colSize))
                    {
                        Movement(newRow, newCol, matrix, ref cheeseCount, ref isTrapped, ref mouseRow, ref mouseCol);
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
                else if (direction == "up")
                {
                    newRow--;
                    if (IsMoveValid(newRow, newCol, rowSize, colSize))
                    {
                        Movement(newRow, newCol, matrix, ref cheeseCount, ref isTrapped, ref mouseRow, ref mouseCol);
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }
                else if (direction == "down")
                {
                    newRow++;
                    if (IsMoveValid(newRow, newCol, rowSize, colSize))
                    {
                        Movement(newRow, newCol, matrix, ref cheeseCount, ref isTrapped, ref mouseRow, ref mouseCol);
                    }
                    else
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }

                if (isTrapped)
                {
                    break;
                }
            }
            if (cheeseCount == 0)
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            else if (isTrapped)
                Console.WriteLine("Mouse is trapped!");
            for (int row = 0; row < rowSize; row++)
            {
                
                for (int col = 0; col < colSize; col++)
                {
                    Console.Write(matrix[row, col]);                    
                }
                Console.WriteLine();
            }

        }

        private static void Movement(int newRow, int newCol, char[,] matrix, ref int cheeseCount, ref bool isTrapped, ref int mouseRow, ref int mouseCol)
        {
            if (matrix[newRow, newCol] == 'C')
            {
                matrix[mouseRow, mouseCol] = '*';
                matrix[newRow, newCol] = 'M';
                cheeseCount--;
                mouseRow = newRow;
                mouseCol = newCol;
            }
            else if (matrix[newRow, newCol] == 'T')
            {
                matrix[newRow, newCol] = 'M';
                matrix[mouseRow, mouseCol] = '*';
                mouseRow = newRow;
                mouseCol = newCol;
                isTrapped = true;
            }
            else if (matrix[newRow, newCol] == '@')
            {
                return;
            }
            else if (matrix[newRow, newCol] == '*')
            {
                matrix[newRow, newCol] = 'M';
                matrix[mouseRow, mouseCol] = '*';
                mouseRow= newRow;
                mouseCol = newCol;
            }
        }

        static bool IsMoveValid(int newRow, int newCol, int rowSize, int colSize)
        {
            return newRow >= 0
                && newRow < rowSize
                && newCol >= 0
                && newCol < colSize;


        }
    }
}