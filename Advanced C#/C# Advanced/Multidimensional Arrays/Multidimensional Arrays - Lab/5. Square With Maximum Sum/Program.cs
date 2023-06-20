namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            int biggestSum = 0;
            int bestRow = 0;
            int bestCol = 0;
            int best2ndRow = 0;
            int best2ndCol = 0;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int sum = 0;
                    if (row + 1 >= rows || col + 1 >= cols)
                        break;

                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        bestRow = matrix[row, col];
                        bestCol = matrix[row, col + 1];
                        best2ndRow = matrix[row + 1, col];
                        best2ndCol = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine($"{bestRow} {bestCol}");
            Console.WriteLine($"{best2ndRow} {best2ndCol}");
            Console.WriteLine(biggestSum);
        }
    }
}