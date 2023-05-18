using System.Data;

namespace _7._Knight_Game_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            for (int row = 0; row < size; row++)
            {
                string info = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = info[col];
                }
            }
            int knightsRemoved = 0;
            
            while (true)
            {
                int rowMostAttacking = 0;
                int colMostAttacking = 0;
                int countMostAttacking = 0;
                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        

                        if (board[row, col] == 'K')
                        {
                            int mostAttacking = MostAttacking(row, col, board, size);

                            if (countMostAttacking < mostAttacking)
                            {
                                rowMostAttacking = row;
                                colMostAttacking = col;
                                countMostAttacking = mostAttacking;
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
        static int MostAttacking(int row, int col, char[,] board, int size)
        {
            int attackedKnights = 0;
            // horizontal-left
            if (IsCellValid(row - 1, col - 2,size)) 
            {
                if(board[row - 1, col - 2] =='K')
                 attackedKnights++; 
            }
            // vertical- left
            if (IsCellValid(row - 2, col - 1, size))
            {
                if (board[row - 2, col - 1] == 'K')
                    attackedKnights++;
            }
            // horizontal-right
            if (IsCellValid(row - 1, col + 2, size))
            {
                    if (board[row - 1, col + 2] == 'K')
                        attackedKnights++;
            }
            // vertical-right
            if (IsCellValid(row - 2, col + 1, size))
            {
                if (board[row - 2, col + 1] == 'K')
                    attackedKnights++;
            }
            // horizontal-left down
            if (IsCellValid(row + 1, col - 2, size))
            {
                if (board[row + 1, col - 2] == 'K')
                    attackedKnights++;
            }// vertical-left down
            if (IsCellValid(row + 2, col - 1, size))
            {
                if (board[row + 2, col - 1] == 'K')
                    attackedKnights++;
            }
            // horizontal-right down
            if (IsCellValid(row + 1, col + 2, size))
            {
                if (board[row + 1, col + 2] == 'K')
                    attackedKnights++;
            }
            // horizontal-right down
            if (IsCellValid(row + 2, col + 1, size))
            {
                if (board[row + 2, col + 1] == 'K')
                    attackedKnights++;
            }
            return attackedKnights;


        }
        static bool IsCellValid(int row, int col, int size)
        {
            return
                row >= 0
             && row < size
             && col >= 0
             && col < size;
        }
    }
}