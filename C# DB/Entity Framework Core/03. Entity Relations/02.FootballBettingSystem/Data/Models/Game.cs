using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int GameId { get; set; }

        public int HomeTeamGoals  { get; set; }

        public int AwayTeamGoals { get; set; }

        // DateTime is required by Default datetime? is nullable
        public DateTime DateTime { get; set; }

        // double is also required by default
        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [MaxLength(10)]
        public string? Result { get; set; }


        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }


        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
