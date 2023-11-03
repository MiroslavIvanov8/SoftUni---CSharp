using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        // we use fluent api for composite key configuration 
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game  { get; set; }


        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public  virtual Player Player { get; set; }

        //Warning !!!
        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }

        public int MinutesPlayed { get; set; }
    }
}
