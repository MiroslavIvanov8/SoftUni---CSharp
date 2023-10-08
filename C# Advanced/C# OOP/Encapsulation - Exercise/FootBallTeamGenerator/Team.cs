using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private int numberOfPlayers;
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            Name = name;
            Players = new List<Player>();
        }
        private List<Player> Players
        {
            get { return players; }
            set
            { players = value; }
        }

        public double Rating
        {
            get { return CalcRating(); }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private int NumberOfPlayers
        {
            get { return players.Count; }
            set
            {
                numberOfPlayers = 0;
            }
        }
        public void Remove(string name)
        {
            Player playerToRemove = players.Find(x => x.Name == name);

            if (playerToRemove != null && Players.Contains(playerToRemove))
            {
                Players.Remove(playerToRemove);
            }
            else
                Console.WriteLine($"Player {name} is not in {Name} team.");
        }
        public void Add(Player player)
        {
            if (!players.Contains(player))
                Players.Add(player);
        }
        private double CalcRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return players.Sum(player => player.SkillLevel) / players.Count;
        }
    }
}
