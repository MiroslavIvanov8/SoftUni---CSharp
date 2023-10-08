using System.Data;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,]matrix =new char[n,n];
            for (int row = 0; row < n; row++)
            { 
                string rowData = Console.ReadLine();
                char[] dataInfo = rowData.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = dataInfo[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
            }
            if (!isFound)
            Console.WriteLine($"{symbol} does not occur in the matrix");    
        }
    }
}