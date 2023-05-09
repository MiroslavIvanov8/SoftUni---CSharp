namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            int leftDiagonal = 0;
            int rightDiagonal = 0;
            for (int row = 0,j = n-1; row < n; row++,j--)
            {
                leftDiagonal += matrix[row, row];
                rightDiagonal += matrix[row, j];
            }
            
            Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal));
        }
    }
}