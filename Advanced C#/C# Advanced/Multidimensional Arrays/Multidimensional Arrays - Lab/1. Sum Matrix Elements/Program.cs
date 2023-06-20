namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] data = Console.ReadLine().Split(", ");

            int rows = int.Parse(data[0]);
            int cols = int.Parse(data[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = int.Parse(rowData[col]);
                }
            }
            int sum = 0;
            for (int row = 0; row < rows; row++)
            { 
                for (int col = 0; col < cols; col++)
                {
                    sum+= matrix[row,col];
                }                
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}