using System.Drawing;

namespace _8._Bombs1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < size; row++)
            {
                int[] rowInfo = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }
            string[] bombs = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach (string bomb in bombs)
            {
               int row = bomb[0]-48;
               int col = bomb[2]-48;
               int bombStrength = matrix[row, col];
               matrix = Explosion(row, col, bombStrength ,matrix, size);
            }

            int aliveCells = AliveCellsCheck(size,matrix);
            int aliveCellsSum = AliveCellsSum(size, matrix);

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(size,matrix);

        }
        static void PrintMatrix(int size, int[,]matrix)
        {
            
            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }
        private static int AliveCellsSum(int size, int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        
                        sum += matrix[row, col];
                    }
                }
            }
            return sum;
        }

        static int AliveCellsCheck(int size, int[,]matrix)
        {
            int aliveCells = 0;
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        
                    }
                }
            }
            return aliveCells;
           
        }
        private static int[,] Explosion(int row, int col, int bombStrength, int[,] matrix, int size)
        {
            // horizontal up
            if (IsCellValid(row-1, col-1,size))
            {
               if (matrix[row - 1, col - 1] >0)
                   matrix[row - 1, col - 1] -= bombStrength;
            }
            if (IsCellValid(row - 1, col , size))
            {
                if (matrix[row - 1, col] > 0)
                    matrix[row - 1, col] -= bombStrength;
            }
            if (IsCellValid(row - 1, col + 1 , size))
            {
                if (matrix[row-1, col + 1] > 0)
                    matrix[row - 1, col + 1] -= bombStrength;
            }
            // left 
            if (IsCellValid(row , col - 1, size))
            {
                if (matrix[row,col - 1] > 0)
                    matrix[row , col - 1] -= bombStrength;
            }
            // right
            if (IsCellValid(row, col + 1, size))
            {
                if (matrix[row, col + 1] > 0)
                    matrix[row, col + 1] -= bombStrength;
            }
            // horizotal down
            if (IsCellValid(row + 1, col - 1, size))
            {
                if (matrix[row + 1,col - 1] > 0)
                    matrix[row + 1, col - 1] -= bombStrength;
            }
            if (IsCellValid(row + 1, col, size))
            {
                if (matrix[row + 1,col] > 0)
                    matrix[row + 1, col] -= bombStrength;
            }
            if (IsCellValid(row + 1, col + 1, size))
            {
                if (matrix[row + 1,col + 1] > 0)
                matrix[row + 1, col + 1] -= bombStrength;
            }
            matrix[row, col] = 0;
            return matrix;

        }
        static bool IsCellValid(int row, int col ,int size)
        {
            return row >= 0
                && row < size
                && col >= 0
                && col < size;

        }
    }
}