using System.Drawing;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            string raceCarNumbrer = Console.ReadLine();            
            int KM = 0;
            for (int row = 0; row < size; row++)
            {
                string[] rowInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            matrix[0, 0] = "C";
            string direction = string.Empty;
            
            while ((direction = Console.ReadLine()) != "End")
            {
                bool moveMade = false;
                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == "C")
                        {
                            if (!moveMade)
                            {
                                moveMade = true;

                                if (direction == "left")
                                {
                                    if (matrix[row, col - 1] == "T")
                                    {
                                        matrix[row, col] = ".";
                                        matrix = TunnelMovement(matrix, row, col - 1, size);
                                        KM += 30;
                                    }
                                    else if (matrix[row, col - 1] == "F")
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                        Console.WriteLine(Finish(raceCarNumbrer));
                                        Console.WriteLine($"Distance covered {KM} km.");
                                        PrintMatrix(matrix, size);                                        
                                        return;
                                    }
                                    else
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                    }
                                }
                                else if (direction == "right")
                                {
                                    if (matrix[row, col + 1] == "T")
                                    {
                                        matrix[row, col] = ".";
                                        matrix = TunnelMovement(matrix, row, col + 1, size);
                                        KM += 30;
                                    }
                                    else if (matrix[row, col + 1] == "F")
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                        Console.WriteLine(Finish(raceCarNumbrer));
                                        Console.WriteLine($"Distance covered {KM} km.");
                                        PrintMatrix(matrix, size);                                       
                                        return;


                                    }
                                    else
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                    }

                                }
                                else if (direction == "up")
                                {
                                    if (matrix[row - 1, col] == "T")
                                    {
                                        matrix[row, col] = ".";
                                        matrix = TunnelMovement(matrix, row - 1, col, size);
                                        KM += 30;
                                    }
                                    else if (matrix[row - 1, col] == "F")
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                        Console.WriteLine(Finish(raceCarNumbrer));
                                        Console.WriteLine($"Distance covered {KM} km.");
                                        PrintMatrix(matrix, size);                                        
                                        return;
                                    }
                                    else
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                    }
                                }
                                else if (direction == "down")
                                {
                                    if (matrix[row + 1, col] == "T")
                                    {
                                        matrix[row, col] = ".";
                                        matrix = TunnelMovement(matrix, row + 1, col, size);
                                        KM += 30;
                                    }
                                    if (matrix[row + 1, col] == "F")
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                        Console.WriteLine(Finish(raceCarNumbrer));
                                        Console.WriteLine($"Distance covered {KM} km.");
                                        PrintMatrix(matrix, size);                                        
                                        return;

                                    }
                                    else
                                    {
                                        matrix = CarMovement(matrix, row, col, size, direction);
                                        KM += 10;
                                    }
                                }
                            }
                        }


                    }
                }
            }

            Console.WriteLine($"Racing car {raceCarNumbrer} DNF.");
            Console.WriteLine($"Distance covered {KM} km.");
            PrintMatrix(matrix, size);

            
        }
        public static void PrintMatrix(string[,]matrix,int size)
        {
            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {
                   Console.Write(matrix[row, col]);
                    
                }
                Console.WriteLine();
            }
        }
        public static string Finish (string raceCarNumber)
        {
            return $"Racing car {raceCarNumber} finished the stage!";
        }
        public static string[,] TunnelMovement(string[,] matrix, int currRow, int currCol, int size)
        {
            matrix[currRow, currCol] = ".";

            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "T")
                    {
                        matrix[row, col] = "C";
                    }
                }
            }
            return matrix;
        }
         
        public static string[,] CarMovement(string[,] matrix,int row, int col,int size,string direction)
        {
            if (direction == "left")
            {
                matrix[row, col - 1] = "C";      
            }
            else if  (direction == "right")
            {
                matrix[row, col + 1] = "C";
            }
            else if (direction == "up")
            {
                matrix[row - 1, col] = "C";
            }
            else if (direction == "down")
            {
                matrix[row + 1, col] = "C";
            }
            matrix[row, col] = ".";
            return matrix;

        }
    }
}