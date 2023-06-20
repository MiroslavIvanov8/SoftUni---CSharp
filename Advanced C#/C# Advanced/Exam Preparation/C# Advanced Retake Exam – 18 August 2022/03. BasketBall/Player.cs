using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public string Name;
        public string Position;
        public double Rating;

        public int Games;

        public bool Retired;
        public Player()
        {
            Retired = false;
        }
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;            
        }
        public override string ToString()
        {
            //"-Player: {name}
            //--Position: {position}
            //--Rating: {rating}
            //--Games played: { games}
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Rating: {Rating}");
            sb.AppendLine($"--Games played: {Games}");
            return sb.ToString().TrimEnd();
            

        }
    }
}
    