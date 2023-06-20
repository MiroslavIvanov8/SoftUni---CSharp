using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int blackCnt = 0;
            int whiteCnt = 0;
            int summerCnt = 0;
            int boarTruffles = 0;
            string[,] matrix = new string[size, size];
            for (int row = 0; row < size; row++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = info[col];
                }
            }

            
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Stop")
                    break;

                if (command[0] == "Collect")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);

                    if (matrix[row, col] == "-")
                        continue;
                    else if (matrix[row, col] == "W")
                        whiteCnt++;
                    else if (matrix[row, col] == "S")
                        summerCnt++;
                    else
                       blackCnt++;
                    matrix[row, col] = "-";
                }
                else if (command[0] == "Wild_Boar")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    string direction = command[3];
                    boarTruffles += WildBoar(row, col, matrix, direction,size);
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackCnt} black, {summerCnt} summer, and {whiteCnt} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");
            PrintMatrix(matrix, size);
        }

        static void PrintMatrix(string[,]matrix,int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        static int WildBoar(int row, int col, string[,] matrix, string direction,int size)
        {
            int trufflesEaten = 0;
            if (matrix[row, col] != "-")
            {
                trufflesEaten++;
                matrix[row,col] = "-";
            }

            if (direction == "up")
            {
                for (int start = row; row < size ;start-=2)
                {
                    if (start < 0)
                        return trufflesEaten;
                    else
                    {
                        if (matrix[start, col] != "-")
                        {
                            trufflesEaten++;
                            matrix[start, col] = "-";
                        }
                    }
                }
            }
            else if (direction == "down")
            {
                for (int start = row; col < size; start += 2)
                {
                    if (start >= size)
                        return trufflesEaten;
                    else
                    {
                        if (matrix[start, col] != "-")
                        {
                            trufflesEaten++;
                            matrix[start, col] = "-";
                        }
                    }
                }
            }
            else if (direction == "left")
            {
                for (int start = col; col < size; start -= 2)
                {
                    if (start < 0)
                        return trufflesEaten;
                    else
                    {
                        if (matrix[row, start] != "-")
                        {
                            trufflesEaten++;
                            matrix[row, start] = "-";
                        }
                    }
                }
            }
            else if (direction == "right")
            {
                for (int start = col; col<size; start += 2)
                {
                    if (start >= size)
                        return trufflesEaten;
                    else
                    {
                        if (matrix[row, start] != "-")
                        {
                            trufflesEaten++;
                            matrix[row, start] = "-";
                        }
                    }
                }
            }
            return trufflesEaten;

        }
    }
}
