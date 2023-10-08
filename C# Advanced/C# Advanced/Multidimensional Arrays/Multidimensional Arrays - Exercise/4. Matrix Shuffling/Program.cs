namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] != "swap" || (commandArgs.Length > 5 || commandArgs.Length < 5))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    int rowToChange = int.Parse(commandArgs[1]);
                    int colToChange = int.Parse(commandArgs[2]);
                    if ((rowToChange > matrix.GetLength(0) || rowToChange < 0)
                        || colToChange > matrix.GetLength(1) || colToChange < 0)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    string token = matrix[rowToChange, (colToChange)];
                    int changedRow = int.Parse(commandArgs[3]);
                    int changedCol = int.Parse(commandArgs[4]);
                    if ((changedRow > matrix.GetLength(0) || changedRow < 0)
                        || changedCol > matrix.GetLength(1) || changedCol < 0)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    matrix[rowToChange, colToChange] = matrix[changedRow, changedCol];
                    matrix[changedRow, changedCol] = token;

                    for (int row = 0; row < dimensions[0]; row++)
                    {
                        for (int col = 0; col < dimensions[1]; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                    
            }
        }
    }
}