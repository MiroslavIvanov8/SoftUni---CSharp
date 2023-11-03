using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design.Internal;

using Microsoft.EntityFrameworkCore;

    public class FootballBettingContext : DbContext
    {
        // we use this ctor to test and develop out application on our pc
        public FootballBettingContext()
        {
                
        }

        // we use this ctor for judge
        //loading of the Dbcontext with Di -> in real applications is usefull 
        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
 


        // connection configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //set default connection string
                //someone used empty construction of out dbcontext
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=FootballBookmakerSystem;Integrated Security=True; TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        // fluent api and entities config
        // TODO Write Fluent API Config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });
            });
        }
    }

