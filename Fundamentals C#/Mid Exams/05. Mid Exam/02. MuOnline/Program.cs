using System;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int HP = 100;
            int bitCoins = 0;
            string[]levels = Console.ReadLine()
                                   .Split("|", StringSplitOptions.RemoveEmptyEntries); // rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000
            for (int i = 0; i < levels.Length; i++)
            {
                string room = levels[i];
                string[] currRoom = room.Split();
                string currRoomType = currRoom[0];
                if (currRoomType == "potion")
                {
                    int potionStr = int.Parse(currRoom[1]);
                    if (HP == 100)
                    {
                        continue;
                    }
                    else
                    {
                        if (HP + potionStr > 100)
                        {
                            Console.WriteLine($"You healed for {100-HP} hp.");
                            HP += potionStr;
                        }                        
                        else
                        {
                            Console.WriteLine($"You healed for {potionStr} hp.");
                            HP += potionStr;
                        }
                    }
                    if (HP > 100)
                    {
                        HP = 100;
                        Console.WriteLine($"Current health: {HP} hp.");

                    }
                    else
                    {
                        Console.WriteLine($"Current health: {HP} hp.");
                    }

                }
                else if (currRoomType == "chest")
                {
                    int bitCoinsInChest = int.Parse(currRoom[1]);
                    bitCoins += bitCoinsInChest;
                    Console.WriteLine($"You found {bitCoinsInChest} bitcoins.");
                }
                else
                {
                    string monster = currRoom[0];
                    int takenHP = int.Parse(currRoom[1]);
                    if (HP - takenHP <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        HP -= takenHP;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                        HP -= takenHP;
                    }
                     
                }
            }
            if(HP>0)
            { Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitCoins}");
                Console.WriteLine($"Health: {HP}");
            }
        }
    }
}
