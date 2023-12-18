using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var players = new Dictionary<string, Player>();
            while ((input = Console.ReadLine()) != "Season end")
            {
                string[] inputArgs = input.Split(" ");

                if (inputArgs[1] == "->")
                {
                    string playerName = inputArgs[0];
                    string playerPosition = inputArgs[2];
                    int playerSkill = int.Parse(inputArgs[4]);
                    if (!players.ContainsKey(playerName))
                    {
                        players[playerName] = new Player() { Position = new Dictionary<string, int>() };
                        players[playerName].Position.Add(playerPosition, playerSkill);
                    }
                    else
                    {
                        if (!players[playerName].Position.ContainsKey(playerPosition))
                        {
                            players[playerName].Position.Add(playerPosition, playerSkill);
                        }
                        else
                        {
                            if (players[playerName].Position[playerPosition] < playerSkill)
                                players[playerName].Position[playerPosition] = playerSkill;
                        }

                    }

                }
                else if (inputArgs[1] == "vs")
                {
                    string attacker = inputArgs[0];
                    string defender = inputArgs[2];
                    if (players.ContainsKey(attacker) && players.ContainsKey(defender))
                    {
                        if (players[attacker].Position.Count >= players[defender].Position.Count)
                        {
                            foreach (var key in players[attacker].Position)
                            {
                                string keyValue = key.Key.ToString();
                                if (players[defender].Position.ContainsKey(keyValue))
                                {
                                    var attackerSum = players[attacker].Position.Sum(x => x.Value);
                                    var defenderSum = players[defender].Position.Sum(x => x.Value);
                                    if (attackerSum > defenderSum)
                                        players.Remove(defender);
                                    else if (attackerSum < defenderSum)
                                        players.Remove(attacker);
                                    else
                                        continue;
                                }
                            }
                        }
                        else
                        {
                            foreach (var key in players[defender].Position)
                            {
                                string keyValue = key.Key.ToString();
                                if (players[attacker].Position.ContainsKey(keyValue))
                                {
                                    var attackerSum = players[attacker].Position.Sum(x => x.Value);
                                    var defenderSum = players[defender].Position.Sum(x => x.Value);
                                    if (attackerSum > defenderSum)
                                        players.Remove(defender);
                                    else if (attackerSum < defenderSum)
                                        players.Remove(attacker);
                                    else
                                        continue;

                                }
                            }
                        }
                    }
                }
            }

            var sortedPlayers = players.OrderByDescending(s => s.Value.Position.Values.Sum());



            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Position.Values.Sum()} skill");

                Console.WriteLine(string.Join(Environment.NewLine, player.Value.Position.OrderByDescending(p => p.Value).Select(u => $"- {u.Key} <::> {u.Value}")));


            }
        }
        public class Player
        {
            public new Dictionary<string, int> Position { get; set; }

        }
    }
}