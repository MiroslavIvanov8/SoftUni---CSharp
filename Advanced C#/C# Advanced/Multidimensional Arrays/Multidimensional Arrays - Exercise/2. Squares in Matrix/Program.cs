namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split();
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                
                }
            }
            
            int counter = 0;
            for (int row = 0; row <matrix.GetLength(0)-1; row++)
            {

                for (int col = 0; col < cols-1; col++)
                {                    
                    if (matrix[row, col] == matrix[row + 1, col + 1])
                        if (matrix[row, col] == matrix[row + 1, col])
                            if (matrix[row, col] == matrix[row, col + 1])                                                            
                                counter++;
                                                       
                                
                }
                
            }
            Console.WriteLine(counter);
        
        }
    }
}