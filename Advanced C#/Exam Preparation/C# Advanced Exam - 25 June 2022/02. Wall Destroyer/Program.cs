using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int vankoRow = 0;
            int vankoCol = 0;
            int rods = 0;
            int holes = 1;
            bool isElectrocuted = false;
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInfo[col];
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "End")
            {
                int newRow = vankoRow;
                int newCol = vankoCol;

                if (direction == "left")
                {
                    newCol -= 1;
                    if (IsValidMove(newRow, newCol, size))
                    {
                        Movement(newRow, newCol, matrix, size, ref vankoRow, ref vankoCol,ref holes, ref rods, ref isElectrocuted);                      
                    }
                }
                else if (direction == "right")
                {
                    newCol += 1;
                    if (IsValidMove(newRow, newCol, size))
                    {
                        Movement(newRow, newCol, matrix, size, ref vankoRow, ref vankoCol, ref holes, ref rods, ref isElectrocuted);
                    }
                }
                else if (direction == "up")
                {
                    newRow -= 1;
                    if (IsValidMove(newRow, newCol, size))
                    {
                        Movement(newRow, newCol, matrix, size, ref vankoRow, ref vankoCol, ref holes, ref rods, ref isElectrocuted);
                    }
                }
                else if (direction == "down")
                {
                    newRow += 1;
                    if (IsValidMove(newRow, newCol, size))
                    {
                        Movement(newRow, newCol, matrix, size, ref vankoRow, ref vankoCol, ref holes, ref rods, ref isElectrocuted);
                    }

                }
                if (isElectrocuted)
                    break;
            }
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }

            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);    
                }
                Console.WriteLine();
            }

        }

        private static void Movement(int newRow, int newCol, char[,] matrix, int size, ref int vankoRow, ref int vankoCol, ref int holes, ref int rods, ref bool isElectrocuted)
        {
            if (matrix[newRow, newCol] == 'R')
            {
                rods++;
                return;
            }
            else if (matrix[newRow, newCol] == 'C')
            {
                isElectrocuted = true;
                matrix[newRow, newCol] = 'E';
                matrix[vankoRow, vankoCol] = '*';
                holes++;
            }
            else if (matrix[newRow, newCol] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{newRow}, {newCol}]!");
                matrix[vankoRow, vankoCol] = '*';                
                matrix[newRow, newCol] = 'V';
                vankoRow= newRow;
                vankoCol= newCol;
            }
            else
            {
                matrix[newRow, newCol] = 'V';
                matrix[vankoRow, vankoCol] = '*';
                holes++;
                vankoRow = newRow;
                vankoCol = newCol;
            }

        }

       
        static bool IsValidMove(int row, int col,int size)
        {
            return row >= 0
                && row < size
                && col >= 0
                && col < size;
        }
    }

}
