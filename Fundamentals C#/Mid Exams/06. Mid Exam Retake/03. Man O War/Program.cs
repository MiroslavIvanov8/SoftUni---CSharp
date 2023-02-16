using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            List<int> warShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            int maxHP = int.Parse(Console.ReadLine());
            string input;
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] commandArgs = input.Split(" ").ToArray();
                string commandType= commandArgs[0];
                if (commandType == "Fire")
                {
                    int index = int.Parse(commandArgs[1]);
                    int damage = int.Parse(commandArgs[2]);
                    if (index < 0 || index > warShip.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            break;
                        }    
                    }
                }
                else if (commandType == "Defend")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    int damage = int.Parse(commandArgs[3]);
                    if (startIndex >= 0 && endIndex <= pirateShip.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                break;
                            }
                        }
                        break;
                    }
                    else
                        continue;
                                    }
                else if (commandType == "Repair")
                {
                    int index = int.Parse(commandArgs[1]);
                    int health = int.Parse(commandArgs[2]);
                    if (index < 0 || index > pirateShip.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (pirateShip[index] + health > maxHP)
                        {
                            pirateShip[index] = maxHP;
                        }
                        else
                        {
                            pirateShip[index] += health;
                        }
                    }
                }
                else if (commandType == "Status")
                {
                    int sectionsToRepair = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < maxHP * 0.20)
                        {
                            sectionsToRepair++;
                        }
                    }
                    Console.WriteLine($"{sectionsToRepair} sections need repair.");
                }
            }
            if (input == "Retire")
            {
                int pirateShipSum = 0;
                int warShipSum = 0;
                for (int i = 0; i < pirateShip.Count; i++)
                {
                    pirateShipSum += pirateShip[i];
                }
                for (int i = 0; i < warShip.Count; i++)
                {
                    warShipSum += warShip[i];
                }
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }
            
        }
        
    }
}
