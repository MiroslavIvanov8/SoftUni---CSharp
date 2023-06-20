namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[size,size];
            int submarineHp = 3;
            int cruisersDown = 0;
            for(int row = 0;row < size; row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    battlefield[row, col] = rowInfo[col];
                }
            }
            int lastRow = 0;
            int lastCol = 0;
            char[,] lastBattlefield = new char[size,size];
            while (true)
            {
                if (submarineHp == 0)
                    break;
                if (cruisersDown == 3)
                    break;
                string direction = Console.ReadLine();
                bool moveMade = false;
                for (int row = 0; row < size; row++)
                {
                    if (!moveMade)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (battlefield[row, col] == 'S')
                            {
                                if (direction == "left")
                                {
                                    lastRow = row;
                                    lastCol = col -1;
                                    lastBattlefield = battlefield;
                                    if (battlefield[row, col - 1] == '*')
                                        submarineHp--;
                                    else if (battlefield[row, col - 1] == 'C')
                                        cruisersDown++;
                                    battlefield = SubMovement(direction, battlefield, row, col, size);
                                    moveMade = true;
                                    break;
                                }
                                else if (direction == "right")
                                {
                                    lastRow = row;
                                    lastCol = col +1;
                                    lastBattlefield = battlefield;
                                    if (battlefield[row, col + 1] == '*')
                                        submarineHp--;
                                    else if (battlefield[row, col + 1] == 'C')
                                        cruisersDown++;
                                    battlefield = SubMovement(direction, battlefield, row, col, size);
                                    moveMade = true;
                                    break;
                                }
                                else if (direction == "up")
                                {
                                    lastRow = row -1;
                                    lastCol = col;
                                    lastBattlefield = battlefield;
                                    if (battlefield[row - 1, col] == '*')
                                        submarineHp--;
                                    else if (battlefield[row - 1, col] == 'C')
                                        cruisersDown++;
                                    battlefield = SubMovement(direction, battlefield, row, col, size);
                                    moveMade = true;
                                    break;
                                }
                                else if (direction == "down")
                                {
                                    lastRow = row + 1;
                                    lastCol = col;
                                    lastBattlefield = battlefield;
                                    if (battlefield[row + 1, col] == '*')
                                        submarineHp--;
                                    else if (battlefield[row + 1, col] == 'C')
                                        cruisersDown++;
                                    battlefield = SubMovement(direction, battlefield, row, col, size);
                                    moveMade = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (submarineHp == 0)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{lastRow}, {lastCol}]!");
                for (int row = 0; row < size; row++)
                {
                    
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(lastBattlefield[row, col]);
                    }
                    Console.WriteLine();
                }
            }
            else if (cruisersDown == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(battlefield[row, col]);
                    }
                    Console.WriteLine();
                }
            }

        }
        static char[,] SubMovement(string direction, char[,] battlefield, int row, int col, int size)
        {
            if (direction == "left")
            {
                battlefield[row, col] = '-';
                battlefield[row, col - 1] = 'S';
            }
            else if (direction == "right")
            {
                battlefield[row, col] = '-';
                battlefield[row, col + 1] = 'S';
            }
            else if (direction == "up")
            {
                battlefield[row, col] = '-';
                battlefield[row - 1, col] = 'S';
            }
            else if (direction == "down")
            {
                battlefield[row, col] = '-';
                battlefield[row + 1, col] = 'S';

            }
            return battlefield;
        }
    }
}