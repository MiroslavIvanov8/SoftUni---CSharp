using System.Runtime.Intrinsics.X86;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int molePoints = 0;
            for(int row=0;row<size; row++)
            {
                string info = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = info[col];
                }
            }
            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "End")
            {
                if (molePoints >= 25)
                    break;
                bool movementDone = false;
                for (int row = 0; row < size; row++)
                {
                    if (!movementDone)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (field[row, col] == 'M')
                            {
                                movementDone = true;

                                int sum = Movement(row, col, field, size, direction);
                                if (sum > 0)
                                    molePoints += sum - 48;

                                else
                                    molePoints += sum;
                                break;

                            }
                        }
                    }
                }
            }
            if (molePoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
            }
            
            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();    
            }
        }

        public static bool IsMovementValid(int row, int col, int size)
        {
                return row>=0
                && row <size
                && col >= 0
                && col < size;
        }
        public static void TunnelMove(int currRow, int currCol, char[,] field, int size)
        {
            
            field[currRow,currCol] = '-';
            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == 'S')
                     field[row, col] = 'M';
                }
            }
            
        }
        public static int Movement (int row, int col, char[,] field,int size, string direction)
        {
            int sum = 0;
            bool tunnelWent = false;
            if (direction == "left")
            {
                if (IsMovementValid(row, col - 1, size))
                {
                    if (char.IsDigit(field[row, col - 1]))
                    {
                        sum = field[row, col - 1];
                    }
                    else if (field[row, col - 1] == 'S')
                    {
                        TunnelMove(row, col - 1, field, size);
                        field[row, col] = '-';
                        tunnelWent = true;
                        sum -= 3;
                    }
                    if (!tunnelWent)
                        field[row, col - 1] = 'M';

                    field[row, col] = '-';
                    return sum;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    return sum;
                }

            }
            else if (direction == "right")
            {
                if (IsMovementValid(row, col + 1, size))
                {
                    if (char.IsDigit(field[row, col+1]))
                    { 
                        sum = field[row, col + 1];
                    }
                    else if (field[row, col + 1] == 'S')
                    {
                        TunnelMove(row, col + 1, field, size);
                        field[row, col] = '-';
                        tunnelWent = true;
                        sum -= 3;
                    }
                    if (!tunnelWent) 
                        field[row, col + 1] = 'M';

                    field[row, col] = '-';
                    return sum;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    return sum;
                }
            }
            else if (direction == "up")
            {
                if (IsMovementValid(row-1, col, size))
                {
                    if (char.IsDigit(field[row -1, col]))
                    {
                        sum = field[row -1, col];
                    }
                    else if (field[row -1, col] == 'S')
                    {
                        TunnelMove(row -1, col, field, size);
                        field[row, col] = '-';
                        tunnelWent = true;
                        sum -= 3;
                    }
                    if (!tunnelWent)
                        field[row - 1, col] = 'M';

                    field[row, col] = '-';
                    return sum;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    return sum;
                }
            }
            else if (direction == "down")
            {
                if (IsMovementValid(row + 1, col, size))
                {
                    if (char.IsDigit(field[row + 1, col]))
                    {
                        sum = field[row + 1, col];
                    }
                    else if (field[row + 1, col] == 'S')
                    {
                        TunnelMove(row +1, col, field, size);
                        field[row, col] = '-';
                        tunnelWent = true;
                        sum -= 3;
                    }
                    if (!tunnelWent) 
                        field[row + 1, col] = 'M';

                    field[row, col] = '-';
                    return sum ;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    return sum;
                }
            }            
                return sum;

            
        }
    }

}