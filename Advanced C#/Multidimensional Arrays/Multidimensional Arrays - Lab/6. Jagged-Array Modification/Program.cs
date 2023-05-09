namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[][] jaggedArr = new int[int.Parse(Console.ReadLine())][];
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ");

                int expectedRow = int.Parse(commandArgs[1]);
                int expectedCol = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (expectedRow < 0 || expectedRow >= jaggedArr.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                if (expectedCol < 0 || expectedCol >= jaggedArr[expectedRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (commandArgs[0] == "Add")
                {
                    jaggedArr[expectedRow][expectedCol] += value;
                }
                else if (commandArgs[0] == "Subtract")
                {
                    jaggedArr[expectedRow][expectedCol] -= value;
                   
                }
            }

            foreach(var arr in jaggedArr)
            {
                Console.WriteLine((string.Join(" ", arr)));
            }
        }
    }
}