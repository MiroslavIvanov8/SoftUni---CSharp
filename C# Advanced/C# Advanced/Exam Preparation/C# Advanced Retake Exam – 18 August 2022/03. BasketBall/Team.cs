using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {

        public List<Player> Players { get; set; }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count => Players.Count;

        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Position==null || player.Name == string.Empty || player.Position== string.Empty)
                return "Invalid player's information.";
            if (OpenPositions==0)
                return "There are no more open positions.";
            if (player.Rating < 80)
                return "Invalid player's rating.";
                       
                Players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            
        }
        public bool RemovePlayer(string name)
        {
            Player player = Players.Find(x => x.Name == name);

            if (player != null)
            {
                Players.Remove(player);
                OpenPositions++;
                return true;
            }

            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            List<Player> removed = new List<Player>();
            removed = Players.FindAll(x => x.Position == position).ToList();
            Players.RemoveAll(x => x.Position == position);
            OpenPositions += removed.Count;
            return removed.Count;
            
        }
        public Player RetirePlayer(string name)
        {
            Player playerToRetire = Players.Find(x => x.Name == name);
            if(playerToRetire!=null)
            { 
                playerToRetire.Retired = true;
                return playerToRetire;
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(x => x.Games >= games).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (Player player in Players.Where(x=>x.Retired==false))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
