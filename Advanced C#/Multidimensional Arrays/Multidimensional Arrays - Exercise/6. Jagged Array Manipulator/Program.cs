namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagMatrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                jagMatrix[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            for (int row = 0; row < n-1; row++)
            {
                if (jagMatrix[row].Length == jagMatrix[row + 1].Length)
                {
                    for (int i = row; i < row+2; i++)
                        for (int col = 0; col < jagMatrix[row].Length; col++)
                        {
                            jagMatrix[i][col] *= 2;
                        }
                }
                else
                {
                    for (int i = row; i < row+2; i++)
                        for (int col = 0; col < jagMatrix[row].Length; col++)
                        {
                            if (i == row + 1)
                            {
                                for(int collum = 0; collum < jagMatrix[row+1].Length; collum++)
                                    jagMatrix[i][collum] /= 2;
                                break;
                            }
                               
                            jagMatrix[i][col] /= 2;
                        }
                }
            }
            string command = string.Empty;            
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if ((row >= n || row < 0) || col >= jagMatrix[row].Length || col < 0)
                    continue;
                    //if(!(row >= 0 && row < n && col >= 0 && col < jagMatrix[row].Length))
                    //    continue;
                if (commandArgs[0] == "Add")    
                {
                    jagMatrix[row][col] += value;
                }
                if (commandArgs[0] == "Subtract")
                {
                    jagMatrix[row][col] -= value;
                }

            }
            foreach(var arr in jagMatrix)
                Console.WriteLine(string.Join(" ", arr));
        }
    }
}