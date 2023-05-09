namespace _7._Knight_Game_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size,size];

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = data[col];
                }
            }
            
            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;
                for (int row = 0; row < size; row++)
                {
                    
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == 'K')
                        {

                            int attackedKnights = CountAttackedKnights(row, col, size, board);
                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }
                if (countMostAttacking == 0)
                    break;
                else
                {
                    board[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }
            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int row, int col, int size, char[,] board)
        {
            int attackedKnights = 0;
            // horizontal up-left
            if (IsCellValid(row - 1, col - 2, size))
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            // horizontal down-left
            if (IsCellValid(row + 1, col - 2, size))
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            // horizontal up-left
            if (IsCellValid(row - 1, col + 2, size))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            // horizontal down-right
            if (IsCellValid(row + 1, col + 2, size))
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            // vertical up-left
            if (IsCellValid(row - 2, col - 1, size))
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            // vertical up-right
            if (IsCellValid(row - 2, col + 1, size))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            // vertical down-left
            if (IsCellValid(row + 2, col - 1, size))
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            // vertical down-right
            if (IsCellValid(row + 2, col + 1, size))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            return attackedKnights;
        }
        static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}