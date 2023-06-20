using System.Numerics;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            int sum = 0;
            int bestSum = 0;
            int starRow = 0;
            int starCol = 0;


            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    sum = 0;
                    sum += matrix[row, col]
                    + matrix[row, col + 1]
                    + matrix[row, col + 2]
                    + matrix[row + 1, col]
                    + matrix[row + 1, col + 1]
                    + matrix[row + 1, col + 2]
                    + matrix[row + 2, col]
                    + matrix[row + 2, col + 1]
                    + matrix[row + 2, col + 2];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        starRow = row;
                        starCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");

            for (int row = starRow; row < starRow+3; row++)
            {
                for (int col = starCol; col < starCol + 3; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}